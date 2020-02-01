using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public static class LoginPost
    {
        //POST Authentication login and receive Bearer Token
        public static async Task<TokenResponse> PostAccessToken(CheetahConfig cheetahConfig, Login login)
        {
            TokenResponse postResp = await (cheetahConfig.ApiUrlRoot + "Token")
                .WithHeader("x-api-key", cheetahConfig.XApiKey)
                .WithBasicAuth(login.Username, login.Password)
                .PostAsync(null)
                .ReceiveJson<TokenResponse>();
                    
            return postResp;
        }
    }
}