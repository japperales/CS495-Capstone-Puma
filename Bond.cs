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
        public long? CallPrice { get; set; }

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
        

        public Bond(long industryId, DateTimeOffset dateOfIssue, DateTimeOffset dateOfMaturity, string incomePaymentFrequencyType, string incomePaymentFrequencyTypeName, long incomePaymentMonth, long incomePaymentDay, string amortizationFrequencyType, string amortizationFrequencyTypeName, string accrualMethodType, string accrualMethodTypeName, DateTimeOffset callDate, long callPrice, string callType, string callTypeName, DateTimeOffset dateOfFirstPayment, long oidPrice, string insurer, string insurerRating, string oddLastCouponType, string oddLastCouponTypeName)
        {
            IndustryId = industryId;
            DateOfIssue = dateOfIssue;
            DateOfMaturity = dateOfMaturity;
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentFrequencyTypeName = incomePaymentFrequencyTypeName;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            AmortizationFrequencyType = amortizationFrequencyType;
            AmortizationFrequencyTypeName = amortizationFrequencyTypeName;
            AccrualMethodType = accrualMethodType;
            AccrualMethodTypeName = accrualMethodTypeName;
            CallDate = callDate;
            CallPrice = callPrice;
            CallType = callType;
            CallTypeName = callTypeName;
            DateOfFirstPayment = dateOfFirstPayment;
            OidPrice = oidPrice;
            Insurer = insurer;
            InsurerRating = insurerRating;
            OddLastCouponType = oddLastCouponType;
            OddLastCouponTypeName = oddLastCouponTypeName;
        }
        
        [JsonConstructor]
        public Bond(int quantity, DateTimeOffset dateOfIssue,
            DateTimeOffset dateOfMaturity, long incomeMonth, long incomeDay, string accrualMethodType,
            DateTimeOffset callDate, long? callPrice, DateTimeOffset dateOfFirstPayment)
        {
            IndustryId = 0;
            DateOfIssue = dateOfIssue;
            DateOfMaturity = dateOfMaturity;
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = incomeMonth;
            IncomePaymentDay = incomeDay;
            AmortizationFrequencyType = null;
            AmortizationFrequencyTypeName = null;
            AccrualMethodType = accrualMethodType;
            AccrualMethodTypeName = null;
            CallDate = callDate;
            CallPrice = callPrice;
            CallType = null;
            CallTypeName = null;
            DateOfFirstPayment = dateOfFirstPayment;
            OidPrice = null;
            Insurer = null;
            InsurerRating = null;
            OddLastCouponType = null;
            OddLastCouponTypeName = null;
        }
    }
}