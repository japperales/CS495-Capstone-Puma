using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.AccountResponse
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
                AccountNumber = "ERROR: Account Number Not Retrieved";
                AccountLegalName = "ERROR: Account Legal Name Not Retrieved";
                Link = "ERROR: Account Link Not Retrieved";
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