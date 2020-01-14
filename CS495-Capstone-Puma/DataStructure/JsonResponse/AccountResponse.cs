using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
{
    public class AccountResponse
    {
        [JsonProperty("AccountId")]
        public int AccountId { get; set; }
        
        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("AccountLegalName")]
        public string AccountLegalName { get; set; }
        
        [JsonProperty("Link")]
        public string Link { get; set; }

        public AccountResponse()
        {
            AccountId = -1;
            AccountNumber = "333333";
            AccountLegalName = "John Doe";
            Link = "";
        }

        [JsonConstructor]
        public AccountResponse(int accountId, string accountNumber, string accountLegalName, string link)
        {
            AccountId = accountId;
            AccountNumber = accountNumber;
            AccountLegalName = accountLegalName;
            Link = link;
        }
    }
}