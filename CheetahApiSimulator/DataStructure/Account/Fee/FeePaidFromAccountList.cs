using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Account
{
    public class FeePaidFromAccountList
    {
        [JsonProperty("FeePaidFromAccountId")]
        public long FeePaidFromAccountId { get; set; }

        [JsonProperty("FeeCollectionType")]
        public string FeeCollectionType { get; set; }

        [JsonProperty("FeeSettingId")]
        public long FeeSettingId { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("Percentage")]
        public long Percentage { get; set; }

        [JsonProperty("PaysOwnFee")]
        public bool PaysOwnFee { get; set; }

        [JsonProperty("PaidByOtherAccountId")]
        public long PaidByOtherAccountId { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public FeePaidFromAccountList(long feePaidFromAccountId, string feeCollectionType, long feeSettingId, long accountId, long percentage, bool paysOwnFee, long paidByOtherAccountId, long institutionIdentityRecordId)
        {
            FeePaidFromAccountId = feePaidFromAccountId;
            FeeCollectionType = feeCollectionType;
            FeeSettingId = feeSettingId;
            AccountId = accountId;
            Percentage = percentage;
            PaysOwnFee = paysOwnFee;
            PaidByOtherAccountId = paidByOtherAccountId;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}