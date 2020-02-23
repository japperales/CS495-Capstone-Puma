using System;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonRequest;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using Flurl;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public static class AssetPost
    {
        //POST TransactionBatch
        public static async Task<TransactionBatchResponse> PostTransactionBatch(CheetahConfig cheetahConfig, string bearerToken,
            TransactionBatchRequest request)
        {
            TransactionBatchResponse postResp = await (cheetahConfig.ApiUrlRoot + "TransactionBatches")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionBatchResponse>();
            
            return postResp;
        }

        //POST Transaction
        public static async Task<TransactionResponse> PostTransaction(CheetahConfig cheetahConfig, string bearerToken, TransactionRequest request)
        {
            Console.WriteLine(request.accountId);
            TransactionResponse postResp = await (cheetahConfig.ApiUrlRoot + "Transactions/Pending")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionResponse>();

            return postResp;
        }

        //POST TransactionBatch Ready & Post commands
        public static async Task PostTransactionBatchProcessor(CheetahConfig cheetahConfig, string bearerToken, int batchId, bool isReadied)
        {
            var urlSuffix = "";

            //If the batch is not yet ready, send the ready request. If the batch is ready, send the post request. 
            urlSuffix = isReadied ? "/Post" : "/Ready";

            await (cheetahConfig.ApiUrlRoot + "TransactionBatches")
                .AppendPathSegment(urlSuffix)
                .SetQueryParam("TransactionBatchIds", batchId)
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(null);
        }
    }
}