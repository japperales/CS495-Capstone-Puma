using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class FeeCreditToTrustee
    {
        [JsonProperty("FeeCreditToIdentityRecordId")]
        public long FeeCreditToIdentityRecordId { get; set; }

        [JsonProperty("FeeSettingScheduleId")]
        public long FeeSettingScheduleId { get; set; }

        [JsonProperty("IdentityRecordId")]
        public long IdentityRecordId { get; set; }

        [JsonProperty("Percentage")]
        public long Percentage { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public FeeCreditToTrustee(long feeCreditToIdentityRecordId, long feeSettingScheduleId, long identityRecordId, long percentage, long institutionIdentityRecordId)
        {
            FeeCreditToIdentityRecordId = feeCreditToIdentityRecordId;
            FeeSettingScheduleId = feeSettingScheduleId;
            IdentityRecordId = identityRecordId;
            Percentage = percentage;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}