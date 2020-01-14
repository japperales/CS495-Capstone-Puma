using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonTransmission
{
    public class AccountRelationshipPOST
    {
        [JsonProperty("AccountId")]
        public int AccountId { get; set; }

        [JsonProperty("IdentityRecordId")]
        public int IdentityRecordId { get; set; }

        [JsonProperty("AccountRelationshipTypeId")]
        public int AccountRelationshipTypeId { get; set; }

        [JsonProperty("OwnershipPercent")]
        public int OwnershipPercent { get; set; }

        [JsonProperty("TrusteePercent")]
        public int TrusteePercent { get; set; }

        [JsonProperty("IsProxyRecipient")]
        public bool IsProxyRecipient { get; set; }

        [JsonProperty("DoesReceiveApprovalLetter")]
        public bool DoesReceiveApprovalLetter { get; set; }

        [JsonProperty("DoesReceiveTradeNotification")]
        public bool DoesReceiveTradeNotification { get; set; }

        [JsonProperty("DoesUseAccunet")]
        public bool DoesUseAccunet { get; set; }

        public AccountRelationshipPOST(int accountId)
        {
            AccountId = accountId;
            IdentityRecordId = 1643;
            AccountRelationshipTypeId = 2;
            OwnershipPercent = 0;
            TrusteePercent = 0;
            IsProxyRecipient = false;
            DoesReceiveApprovalLetter = false;
            DoesReceiveTradeNotification = false;
            DoesUseAccunet = false;
        }
        
        public AccountRelationshipPOST(int accountId, int identityRecordId)
        {
            AccountId = accountId;
            IdentityRecordId = identityRecordId;
            AccountRelationshipTypeId = 6;
            OwnershipPercent = 1;
            TrusteePercent = 0;
            IsProxyRecipient = false;
            DoesReceiveApprovalLetter = false;
            DoesReceiveTradeNotification = false;
            DoesUseAccunet = false;
        }
    }
}