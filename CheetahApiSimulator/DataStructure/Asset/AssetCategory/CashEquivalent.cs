using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
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
        public long? IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long? IncomePaymentDay { get; set; }

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
        public long? DepositoryIdentityRecordId { get; set; }

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

        public CashEquivalent()
        {
            QualityRating = null;
            DateOfIssue = null;
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = null;
            IncomePaymentDay = null;
            AmortizationFrequencyType = null;
            AmortizationFrequencyTypeName = null;
            AccrualMethodType = null;
            AccrualMethodTypeName = null;
            CompoundingFrequencyType = null;
            CompoundingFrequencyTypeName = null;
            DepositoryIdentityRecordId = null;
            StableNav = null;
            DateOfMaturity = null;
            DateOfFirstPayment = null;
            OddLastCouponType = null;
            OddLastCouponTypeName = null;
        }

        [JsonConstructor]
        public CashEquivalent(string incomePaymentFrequencyType, int incomePaymentMonth, int incomePaymentDay, string accrualMethodType, string compoundingFrequencyType)
        {
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentMonth = incomePaymentDay;
            IncomePaymentDay = incomePaymentDay;
            AccrualMethodType = accrualMethodType;
            CompoundingFrequencyType = compoundingFrequencyType;
        }
    }
}