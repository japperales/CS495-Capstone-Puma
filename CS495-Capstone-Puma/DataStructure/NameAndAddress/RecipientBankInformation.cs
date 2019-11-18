using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.NameAndAddress
{
    public class RecipientBankInformation
    {
        [JsonProperty("IdentityRecordId")]
        public long IdentityRecordId { get; set; }

        [JsonProperty("DepositoryIdentityRecordId")]
        public long DepositoryIdentityRecordId { get; set; }

        [JsonProperty("RecipientAccountName")]
        public string RecipientAccountName { get; set; }

        [JsonProperty("RecipientAccountNumber")]
        public string RecipientAccountNumber { get; set; }

        [JsonProperty("IsSavings")]
        public bool IsSavings { get; set; }

        [JsonConstructor]
        public RecipientBankInformation(long identityRecordId, long depositoryIdentityRecordId, string recipientAccountName, string recipientAccountNumber, bool isSavings)
        {
            IdentityRecordId = identityRecordId;
            DepositoryIdentityRecordId = depositoryIdentityRecordId;
            RecipientAccountName = recipientAccountName;
            RecipientAccountNumber = recipientAccountNumber;
            IsSavings = isSavings;
        }
    }
}