using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure.AccountResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public static class AccountPost
    {
        public static async Task<AccountResponse> PostAccount(string bearerToken, string apiUrlRoot)
        {
            AccountResponse postResp = await (apiUrlRoot + "Accounts")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(new AccountRequest())
                .ReceiveJson<AccountResponse>();

            await (apiUrlRoot + "Accounts/" + postResp.AccountId + "/Open")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync("");
            return postResp;
        }
    }
}