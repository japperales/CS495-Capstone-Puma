 using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Threading.Tasks;
 using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.AccountResponse;
 using CS495_Capstone_Puma.DataStructure.JsonRequest;
 using CS495_Capstone_Puma.DataStructure.JsonResponse;
 using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
 using CS495_Capstone_Puma.DataStructure.ResponseShards;
 using Microsoft.AspNetCore.Mvc;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.Model 
  {
    public static class CheetahHandler
    {
        private static readonly CheetahConfig CheetahConfig = LoadApiConfig();
        private static readonly ProposalGet ProposalGet = new ProposalGet();

        public static CheetahConfig LoadApiConfig()
        {
            using (StreamReader file = File.OpenText(@".\\cheetah-config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                CheetahConfig cheetahConfig = (CheetahConfig) serializer.Deserialize(file, typeof(CheetahConfig));
                return cheetahConfig;
            }
        }
        
        //Coordinates Login (bearerToken retrieval) POST
        public static TokenResponse PostLogin(Login login)
        {
            try
            {
                TokenResponse bearerToken = LoginPost.PostAccessToken(CheetahConfig, login).Result;
                return bearerToken;
            }
            //If the login is incorrect, an exception is thrown and the login is not accepted
            catch (Exception e)
            {
                Console.WriteLine("There was an error while attempting to retrieve an access token: " + e);
                return new TokenResponse(null, -1, null, null, false);
            }
            
        }
        
        //Coordinates Asset/Transaction POST
        public static async Task<AccountResponse> PostAssets(string bearerToken, List<AssetInput> assets)
        {
            try
            {
                AccountResponse accountResponse = AccountPost.PostAccount(bearerToken, CheetahConfig.ApiUrlRoot).Result;
                Console.WriteLine("Account Id right after posting the account supposedly is: " + accountResponse.AccountId);
                
                //Create new Transaction Batch
                int batchId = AssetPost.PostTransactionBatch(CheetahConfig, bearerToken, new TransactionBatchRequest()).Result.transactionBatchId;
                Console.WriteLine(batchId);
                //Turn asset list into a list of transactions to POST
                List<TransactionRequest> transactions = AssembleTransactions(bearerToken, batchId, assets, accountResponse.AccountId);
                
                //POST each transaction
                foreach (TransactionRequest transaction in transactions)
                {
                    Console.WriteLine(transaction.assetId);
                    await AssetPost.PostTransaction(CheetahConfig, bearerToken, transaction);
                }
                
                Console.WriteLine("success 1");
                
                await AssetPost.PostTransactionBatchProcessor(CheetahConfig, bearerToken, batchId, false);
                await AssetPost.PostTransactionBatchProcessor(CheetahConfig, bearerToken, batchId, true);

                return accountResponse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        
        //Coordinates Proposed Trade GET
        public static async Task<object[]> GetTradeProposal(string bearerToken, string accountId)
        {
            Object[] responseArray= new Object[4];
            responseArray[2] = 484934.46;
            responseArray[3] = 5891.01;
            Object[] portfolioArrays = await ProposalGet.GetOriginalAndRevisedPortfolio(CheetahConfig, bearerToken, accountId);
            responseArray[0] = portfolioArrays[0];
            responseArray[1] = portfolioArrays[1];
            return responseArray;
        }

        //Assemble list of Transactions from Assets list
        private static List<TransactionRequest> AssembleTransactions(string bearerToken, int batchId, List<AssetInput> assets, int accountId)
        {
            //Populate Dictionary of assets from Cheetah with a GET request
            Dictionary<AssetIdentifier, int> allAssets = PopulateAssetsDictionary(bearerToken);
            
            //Instantiate TransactionRequest List
            List<TransactionRequest> transactionRequests = new List<TransactionRequest>();
            
            //for each asset in assets, check for entry in Dict
            foreach (AssetInput asset in assets)
            {
                try
                {
                    
                    Console.WriteLine("current asset is: " + asset.units + " , " + asset.assetIdentifier);
                    int assetId = allAssets[asset.assetIdentifier];
                    
                    //Once found, build request and POST to the batch
                    transactionRequests.Add(new TransactionRequest(
                        accountId, batchId, 26, 19, assetId, asset.units));
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Key not found");
                }
            }
            return transactionRequests;
        }

        //Dictionary to match assets to internal id
        private static Dictionary<AssetIdentifier, int> PopulateAssetsDictionary(string bearerToken)
        {
            Dictionary<AssetIdentifier, int> assetsDictionary =
                new Dictionary<AssetIdentifier, int>(new AssetIdentifier.AssetEqualityComparer());
            
            List<AssetLookupResponse> assetLookupResponses = Lookup.GetLookupAssets(CheetahConfig, bearerToken).Result.items;
            
            foreach (AssetLookupResponse assetLookupResponse in assetLookupResponses)
            {
                try
                {
                    assetsDictionary.Add(assetLookupResponse.value, Int32.Parse(assetLookupResponse.id));
                }
                catch (ArgumentException){}
            }
            return assetsDictionary;
        }
        
        //Return Assets from Lookup
        public static List<AssetLookupResponse> GetFullAssetList(string bearerToken)
        {
            return Lookup.GetLookupAssets(CheetahConfig, bearerToken).Result.items;
        }
    }
}