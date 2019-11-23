using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Account
{
    public class FeeSchedule
    {
        [JsonProperty("FeeSettingScheduleId")]
        public long FeeSettingScheduleId { get; set; }

        [JsonProperty("FeeSettingId")]
        public long FeeSettingId { get; set; }

        [JsonProperty("FeeScheduleId")]
        public long FeeScheduleId { get; set; }

        [JsonProperty("FeeAssessmentFrequencyType")]
        public string FeeAssessmentFrequencyType { get; set; }

        [JsonProperty("PrincipalPercentage")]
        public long PrincipalPercentage { get; set; }

        [JsonProperty("DiscountPercentage")]
        public long DiscountPercentage { get; set; }

        [JsonProperty("UseGroupFeeSettingPrincipalPercentageOverride")]
        public bool UseGroupFeeSettingPrincipalPercentageOverride { get; set; }

        [JsonProperty("ExcludedAccounts")]
        public string ExcludedAccounts { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("FeeCreditToTrustees")]
        public List<FeeCreditToTrustee> FeeCreditToTrustees { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public FeeSchedule(long feeSettingScheduleId, long feeSettingId, long feeScheduleId, string feeAssessmentFrequencyType, long principalPercentage, long discountPercentage, bool useGroupFeeSettingPrincipalPercentageOverride, string excludedAccounts, bool isActive, List<FeeCreditToTrustee> feeCreditToTrustees, long institutionIdentityRecordId)
        {
            FeeSettingScheduleId = feeSettingScheduleId;
            FeeSettingId = feeSettingId;
            FeeScheduleId = feeScheduleId;
            FeeAssessmentFrequencyType = feeAssessmentFrequencyType;
            PrincipalPercentage = principalPercentage;
            DiscountPercentage = discountPercentage;
            UseGroupFeeSettingPrincipalPercentageOverride = useGroupFeeSettingPrincipalPercentageOverride;
            ExcludedAccounts = excludedAccounts;
            IsActive = isActive;
            FeeCreditToTrustees = feeCreditToTrustees;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}