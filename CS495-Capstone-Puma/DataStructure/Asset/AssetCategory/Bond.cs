using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset.AssetCategory
{
    public class Bond
    {
        [JsonProperty("IndustryId")]
        public long? IndustryId { get; set; }

        [JsonProperty("DateOfIssue")]
        public DateTimeOffset? DateOfIssue { get; set; }

        [JsonProperty("DateOfMaturity")]
        public DateTimeOffset? DateOfMaturity { get; set; }

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

        [JsonProperty("CallDate")]
        public DateTimeOffset? CallDate { get; set; }

        [JsonProperty("CallPrice")]
        public DateTimeOffset? CallPrice { get; set; }

        [JsonProperty("CallType")]
        public string CallType { get; set; }

        [JsonProperty("CallTypeName")]
        public string CallTypeName { get; set; }

        [JsonProperty("DateOfFirstPayment")]
        public DateTimeOffset? DateOfFirstPayment { get; set; }

        [JsonProperty("OIDPrice")]
        public long? OidPrice { get; set; }

        [JsonProperty("Insurer")]
        public string Insurer { get; set; }

        [JsonProperty("InsurerRating")]
        public string InsurerRating { get; set; }

        [JsonProperty("OddLastCouponType")]
        public string OddLastCouponType { get; set; }

        [JsonProperty("OddLastCouponTypeName")]
        public string OddLastCouponTypeName { get; set; }

        
        public Bond()
        {
            IndustryId = null;
            DateOfIssue = null;
            DateOfMaturity = null;
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = null;
            IncomePaymentDay = null;
            AmortizationFrequencyType = null;
            AmortizationFrequencyTypeName = null;
            AccrualMethodType = null;
            AccrualMethodTypeName = null;
            CallDate = null;
            CallPrice = null;
            CallType = null;
            CallTypeName = null;
            DateOfFirstPayment = null;
            OidPrice = null;
            Insurer = null;
            InsurerRating = null;
            OddLastCouponType = null;
            OddLastCouponTypeName = null;
        }

        [JsonConstructor]
        public Bond(DateTimeOffset? dateOfIssue, DateTimeOffset? dateOfMaturity, string incomePaymentFrequencyType, long? incomePaymentMonth, long? incomePaymentDay, string amortizationFrequencyType, string accrualMethodType, DateTimeOffset? callDate, DateTimeOffset? callPrice, string callType, DateTimeOffset? dateOfFirstPayment, long? oidPrice, string insurer, string insurerRating, string oddLastCouponType)
        {
            DateOfIssue = dateOfIssue;
            DateOfMaturity = dateOfMaturity;
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            AmortizationFrequencyType = amortizationFrequencyType;
            AccrualMethodType = accrualMethodType;
            CallDate = callDate;
            CallPrice = callPrice;
            CallType = callType;
            DateOfFirstPayment = dateOfFirstPayment;
            OidPrice = oidPrice;
            Insurer = insurer;
            InsurerRating = insurerRating;
            OddLastCouponType = oddLastCouponType;
        }
    }
}