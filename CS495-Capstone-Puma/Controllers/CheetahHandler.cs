 ﻿using System;
 using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using CS495_Capstone_Puma.DataStructure.Asset;
  using CS495_Capstone_Puma.DataStructure.JsonRequest;
  using CS495_Capstone_Puma.DataStructure.JsonResponse;
  using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
  using Flurl;
  using Flurl.Http;
  using Microsoft.CodeAnalysis.Operations;

  namespace CS495_Capstone_Puma.Controllers 
  {
    public class CheetahHandler
    {

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<string> PostTransactions(List<AssetInput> assets)
        {
            //POST Authentication
            String bearerToken = postAccessToken().Result.Jwt;
            
            //POST TransactionBatch
            int batchId = postTransactionBatch(bearerToken, new TransactionBatchRequest()).Result.transactionBatchId;

            //POST Transactions (Assets already owned)

            List<TransactionRequest> transactions = assembleTransactions(bearerToken, batchId, assets);
            
            foreach (TransactionRequest transaction in transactions)
            {
                await postTransaction(bearerToken, transaction);
            }
            
            await postTransactionBatchProcessor(bearerToken, batchId, false);
            await postTransactionBatchProcessor(bearerToken, batchId, true);
            
            //Cannot Analyze yet - have to make a second function
            //return relevant info to keep using it
            return bearerToken;
        }

        public async Task getTradeProposal(string bearerToken, int accountId)
        {
            getTrades(bearerToken, accountId);
        }
        
        //POST Authentication login and receive Bearer Token
        public async Task<TokenResponse> postAccessToken()
        {
            TokenResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Token"
                .WithHeader("x-api-key", 
                    "***REMOVED***"
                    )
                .WithBasicAuth("***REMOVED***", "***REMOVED***")
                .PostAsync(null)
                .ReceiveJson<TokenResponse>();
                    
            return postResp;
        } 
        
        //POST TransactionBatch
        public async Task<TransactionBatchResponse> postTransactionBatch(string bearerToken, TransactionBatchRequest request)
        {
            TransactionBatchResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionBatchResponse>();

            return postResp;
        }
        
        //POST Transaction
        private async Task<TransactionResponse> postTransaction(string bearerToken, TransactionRequest request)
        {
            TransactionResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Transactions/Pending"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionResponse>();

            return postResp;
        }

        //POST TransactionBatch Ready & Post commands
        private async Task postTransactionBatchProcessor(string bearerToken, int batchId, bool isReadied)
        {
            string urlSuffix = "";
            
            if (!isReadied)
            {
                urlSuffix = "/Ready";
            }
            else
            {
                urlSuffix = "/Post";
            }
            
            await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .AppendPathSegment(urlSuffix)
                .SetQueryParam("TransactionBatchIds",batchId)
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostAsync(null);
        }
        
        //GET analyzed Trade suggestions
        private async Task<TradeResponse> getTrades(string bearerToken, int accountId)
        {
            TradeResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Accounts"
                .AppendPathSegment(accountId)
                .AppendPathSegment("Trades")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .GetAsync()
                .ReceiveJson<TradeResponse>();

            return postResp;
        }
        
        //Assemble list of Transactions from Assets list
        private List<TransactionRequest> assembleTransactions(string bearerToken, int batchId, List<AssetInput> assets)
        {
            //Populate Dictionary of assets from Cheetah with a GET request
            Dictionary<AssetIdentifier, int> allAssets = populateAssetsDictionary(bearerToken);
            
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
                    Console.WriteLine("Key not found");
                }
            }
            return transactionRequests;
        }

        public Dictionary<AssetIdentifier, int> populateAssetsDictionary(string bearerToken)
        {
            Dictionary<AssetIdentifier, int> assetsDictionary =
                new Dictionary<AssetIdentifier, int>(new AssetIdentifier.AssetEqualityComparer());
            
            List<AssetLookupResponse> assetLookupResponses = getLookupAssets(bearerToken).Result.items;
            
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

        private async Task<LookupResponse> getLookupAssets(string bearerToken)
        {
            LookupResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Lookup?LookupService=GetAssetValues"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .GetAsync()
                .ReceiveJson<LookupResponse>();

            return postResp;
        }
    }
}