using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Account
{
    public class FeeSetting
    {
        [JsonProperty("FeeSettingId")]
        public long FeeSettingId { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("InvoiceFrequencyType")]
        public string InvoiceFrequencyType { get; set; }

        [JsonProperty("MonthYearEnd")]
        public long MonthYearEnd { get; set; }

        [JsonProperty("AnnualMaximumFeeAmount")]
        public long AnnualMaximumFeeAmount { get; set; }

        [JsonProperty("AnnualMinimumFeeAmount")]
        public long AnnualMinimumFeeAmount { get; set; }

        [JsonProperty("PrincipalPercentageOverride")]
        public long PrincipalPercentageOverride { get; set; }

        [JsonProperty("CollectFeesInAdvance")]
        public bool CollectFeesInAdvance { get; set; }

        [JsonProperty("IsGroup")]
        public bool IsGroup { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("FeePaidFromAccountList")]
        public List<FeePaidFromAccountList> FeePaidFromAccountList { get; set; }

        [JsonProperty("FeeSchedules")]
        public List<FeeSchedule> FeeSchedules { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public FeeSetting(long feeSettingId, long accountId, string name, string invoiceFrequencyType, long monthYearEnd, long annualMaximumFeeAmount, long annualMinimumFeeAmount, long principalPercentageOverride, bool collectFeesInAdvance, bool isGroup, bool isActive, List<FeePaidFromAccountList> feePaidFromAccountList, List<FeeSchedule> feeSchedules, long institutionIdentityRecordId)
        {
            FeeSettingId = feeSettingId;
            AccountId = accountId;
            Name = name;
            InvoiceFrequencyType = invoiceFrequencyType;
            MonthYearEnd = monthYearEnd;
            AnnualMaximumFeeAmount = annualMaximumFeeAmount;
            AnnualMinimumFeeAmount = annualMinimumFeeAmount;
            PrincipalPercentageOverride = principalPercentageOverride;
            CollectFeesInAdvance = collectFeesInAdvance;
            IsGroup = isGroup;
            IsActive = isActive;
            FeePaidFromAccountList = feePaidFromAccountList;
            FeeSchedules = feeSchedules;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}