using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public static class Lookup
    {
        public static async Task<LookupResponse> GetLookupAssets(CheetahConfig cheetahConfig, string bearerToken)
        {
            LookupResponse postResp = await (cheetahConfig.ApiUrlRoot + "Lookup?LookupService=GetAssetValues")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .GetAsync()
                .ReceiveJson<LookupResponse>();
        
            return postResp;
        }
    }
}