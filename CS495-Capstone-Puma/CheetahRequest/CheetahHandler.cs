 using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Threading.Tasks;
 using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.JsonRequest;
 using CS495_Capstone_Puma.DataStructure.JsonResponse;
 using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
 using CS495_Capstone_Puma.DataStructure.ResponseShards;
 using Microsoft.AspNetCore.Mvc;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.Model 
  {
    public class CheetahHandler
    {
        private readonly CheetahConfig _cheetahConfig = LoadApiConfig();
        private readonly ProposalGet _proposalGet = new ProposalGet();

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
        public TokenResponse PostLogin(Login login)
        {
            try
            {
                TokenResponse bearerToken = LoginPost.PostAccessToken(_cheetahConfig, login).Result;
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
        public async Task<string> PostAssets(string bearerToken, List<AssetInput> assets)
        {
            try
            {
                //Create new Transaction Batch
                int batchId = AssetPost.PostTransactionBatch(_cheetahConfig, bearerToken, new TransactionBatchRequest()).Result.transactionBatchId;
                
                //Turn asset list into a list of transactions to POST
                List<TransactionRequest> transactions = AssembleTransactions(bearerToken, batchId, assets);
                
                //POST each transaction
                foreach (TransactionRequest transaction in transactions)
                {
                    await AssetPost.PostTransaction(_cheetahConfig, bearerToken, transaction);
                }
                
                await AssetPost.PostTransactionBatchProcessor(_cheetahConfig, bearerToken, batchId, false);
                await AssetPost.PostTransactionBatchProcessor(_cheetahConfig, bearerToken, batchId, true);

                return "PostAssets Successful";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "PostAssets Error";
            }
        }
        
        //Coordinates Proposed Trade GET
        public async Task<Object[]> GetTradeProposal(string bearerToken, string accountId)
        {
            //await getTrades(bearerToken, accountId);
                    
            IList<HoldingsShard> originalPortfolio = _proposalGet.RetrieveOriginalPortfolio(_cheetahConfig, bearerToken, accountId).Result;
                    
            IList<TradeShard> tradeProposal = _proposalGet.RetrieveTradeProposal(_cheetahConfig, bearerToken, accountId).Result;
                    
            Object[] responseArray= new Object[4];
            responseArray[0] = originalPortfolio;
            responseArray[1] = tradeProposal;
            responseArray[2] = 484934.46;
            responseArray[3] = 5891.01;
            await _proposalGet.GetOriginalAndRevisedPortfolio(_cheetahConfig, bearerToken, accountId);
            return responseArray;
        }

        //Assemble list of Transactions from Assets list
        private List<TransactionRequest> AssembleTransactions(string bearerToken, int batchId, List<AssetInput> assets)
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
                    int assetId = allAssets[asset.assetIdentifier];
                    
                    //Once found, build request and POST to the batch
                    transactionRequests.Add(new TransactionRequest(
                        534, batchId, 26, 19, assetId, asset.units));
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
        private Dictionary<AssetIdentifier, int> PopulateAssetsDictionary(string bearerToken)
        {
            Dictionary<AssetIdentifier, int> assetsDictionary =
                new Dictionary<AssetIdentifier, int>(new AssetIdentifier.AssetEqualityComparer());
            
            List<AssetLookupResponse> assetLookupResponses = Lookup.GetLookupAssets(_cheetahConfig, bearerToken).Result.items;
            
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
    }
}