using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset.AssetCategory
{
    public class CashEquivalent
    {
        [JsonProperty("QualityRating", NullValueHandling = NullValueHandling.Ignore)]
        public string QualityRating { get; set; }

        [JsonProperty("DateOfIssue", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateOfIssue { get; set; }

        [JsonProperty("IncomePaymentFrequencyType")]
        public string IncomePaymentFrequencyType { get; set; }

        [JsonProperty("IncomePaymentFrequencyTypeName")]
        public string IncomePaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentMonth")]
        public long IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long IncomePaymentDay { get; set; }

        [JsonProperty("AmortizationFrequencyType")]
        public string AmortizationFrequencyType { get; set; }

        [JsonProperty("AmortizationFrequencyTypeName")]
        public string AmortizationFrequencyTypeName { get; set; }

        [JsonProperty("AccrualMethodType")]
        public string AccrualMethodType { get; set; }

        [JsonProperty("AccrualMethodTypeName")]
        public string AccrualMethodTypeName { get; set; }

        [JsonProperty("CompoundingFrequencyType")]
        public string CompoundingFrequencyType { get; set; }

        [JsonProperty("CompoundingFrequencyTypeName")]
        public string CompoundingFrequencyTypeName { get; set; }

        [JsonProperty("DepositoryIdentityRecordId")]
        public long DepositoryIdentityRecordId { get; set; }

        [JsonProperty("StableNAV", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StableNav { get; set; }

        [JsonProperty("DateOfMaturity", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateOfMaturity { get; set; }

        [JsonProperty("DateOfFirstPayment", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateOfFirstPayment { get; set; }

        [JsonProperty("OddLastCouponType", NullValueHandling = NullValueHandling.Ignore)]
        public string OddLastCouponType { get; set; }

        [JsonProperty("OddLastCouponTypeName", NullValueHandling = NullValueHandling.Ignore)]
        public string OddLastCouponTypeName { get; set; }
        
        
    }
}