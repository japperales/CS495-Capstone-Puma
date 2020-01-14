 ﻿using System;
 using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using CS495_Capstone_Puma.DataStructure.Asset;
  using CS495_Capstone_Puma.DataStructure.JsonRequest;
  using CS495_Capstone_Puma.DataStructure.JsonResponse;
  using Flurl;
  using Flurl.Http;

  namespace CS495_Capstone_Puma.Controllers 
  {
    public class CheetahHandler
    {

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<string> postTransactions(List<Asset> assets)
        {
            //POST Authentication
            String bearerToken = postAccessToken().Result.Jwt;
            
            //POST TransactionBatch
            int batchId = postTransactionBatch(bearerToken, new TransactionBatchRequest()).Result.transactionBatchId;

            //POST Transactions (Assets already owned)
            foreach (Asset asset in assets)
            {
                //Lookup Asset in CheetahDB
                //Map GetAssetValues to Hashmap and search against values
                int assetId = 1; //Perform lookup
                int units = 0; //Located in Asset somewhere
                
                //Once found, build request and POST to the batch
                TransactionRequest transactionRequest = new TransactionRequest(534, batchId, 26,
                    19, assetId, units);
                await postTransaction(bearerToken, transactionRequest);
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
                    "DELETE BEFORE VERSIONING"
                    )
                .WithBasicAuth("DELETE BEFORE VERSIONING", "DELETE BEFORE VERSIONING")
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
                .PutJsonAsync(request)
                .ReceiveJson<TransactionBatchResponse>();

            return postResp;
        }
        
        //POST Transaction
        public async Task<TransactionResponse> postTransaction(string bearerToken, TransactionRequest request)
        {
            TransactionResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PutJsonAsync(request)
                .ReceiveJson<TransactionResponse>();

            return postResp;
        }

        //POST TransactionBatch Ready & Post commands
        public async Task postTransactionBatchProcessor(string bearerToken, int batchId, bool isReadied)
        {
            string urlSuffix = "";
            
            if (!isReadied)
            {
                urlSuffix = "/Ready?TransactionBatchIds=" + batchId;
            }
            else
            {
                urlSuffix = "/Post?TransactionBatchIds=" + batchId;
            }
            
            await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches".AppendPathSegment(urlSuffix)
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostAsync(null);
        }
        
        //GET analyzed Trade suggestions
        public async Task<TradeResponse> getTrades(string bearerToken, int accountId)
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
    }
}