using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset.AssetCategory
{
    public class Loan
    {
        [JsonProperty("DateOfIssue")]
        public DateTimeOffset? DateOfIssue { get; set; }

        [JsonProperty("DateOfMaturity")]
        public DateTimeOffset? DateOfMaturity { get; set; }

        [JsonProperty("DateOfFirstPayment")]
        public DateTimeOffset? DateOfFirstPayment { get; set; }

        [JsonProperty("OddLastCouponType")]
        public string OddLastCouponType { get; set; }

        [JsonProperty("OddLastCouponTypeName")]
        public string OddLastCouponTypeName { get; set; }

        [JsonProperty("PaymentFrequencyType")]
        public string PaymentFrequencyType { get; set; }

        [JsonProperty("PaymentFrequencyTypeName")]
        public string PaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentFrequencyType")]
        public string IncomePaymentFrequencyType { get; set; }

        [JsonProperty("IncomePaymentFrequencyTypeName")]
        public string IncomePaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentMonth")]
        public long? IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long? IncomePaymentDay { get; set; }

        [JsonProperty("CompoundingFrequencyType")]
        public string CompoundingFrequencyType { get; set; }

        [JsonProperty("CompoundingFrequencyTypeName")]
        public string CompoundingFrequencyTypeName { get; set; }

        [JsonProperty("AmortizationFrequencyType")]
        public string AmortizationFrequencyType { get; set; }

        [JsonProperty("AmortizationFrequencyTypeName")]
        public string AmortizationFrequencyTypeName { get; set; }

        [JsonProperty("AccrualMethodType")]
        public string AccrualMethodType { get; set; }

        [JsonProperty("AccrualMethodTypeName")]
        public string AccrualMethodTypeName { get; set; }

        [JsonProperty("DepositoryIdentityRecordId")]
        public long? DepositoryIdentityRecordId { get; set; }

        [JsonProperty("LenderIdentityRecordId")]
        public long? LenderIdentityRecordId { get; set; }

        [JsonProperty("BorrowerIdentityRecordId")]
        public long? BorrowerIdentityRecordId { get; set; }

        [JsonProperty("PeriodicPaymentAmount")]
        public long? PeriodicPaymentAmount { get; set; }

        [JsonProperty("ExcludeFromDelinquencyReporting")]
        public bool? ExcludeFromDelinquencyReporting { get; set; }

        [JsonProperty("DateExcludeFromDelinquencyExpiration")]
        public DateTimeOffset? DateExcludeFromDelinquencyExpiration { get; set; }
        
        public Loan()
        {
            DateOfIssue = null;
            DateOfMaturity = null;
            DateOfFirstPayment = null;
            OddLastCouponType = null;
            OddLastCouponTypeName = null;
            PaymentFrequencyType = null;
            PaymentFrequencyTypeName = null;
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = null;
            IncomePaymentDay = null;
            CompoundingFrequencyType = null;
            CompoundingFrequencyTypeName = null;
            AmortizationFrequencyType = null;
            AmortizationFrequencyTypeName = null;
            AccrualMethodType = null;
            AccrualMethodTypeName = null;
            DepositoryIdentityRecordId = null;
            LenderIdentityRecordId = null;
            BorrowerIdentityRecordId = null;
            PeriodicPaymentAmount = null;
            ExcludeFromDelinquencyReporting = null;
            DateExcludeFromDelinquencyExpiration = null;
        }
        [JsonConstructor]
        public Loan(DateTimeOffset dateOfIssue, DateTimeOffset dateOfMaturity,
            DateTimeOffset dateOfFirstPayment, int incomePaymentMonth, int incomePaymentDay, string accrualMethodType,
            string paymentFrequencyType, string incomePaymentFrequencyType, string compoundingFrequencyType,
            string amortizationFrequencyType, int periodicPaymentAmount)
        {
            DateOfIssue = dateOfIssue;
            DateOfMaturity = dateOfMaturity;
            DateOfFirstPayment = dateOfFirstPayment;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            AccrualMethodType = accrualMethodType;
            PaymentFrequencyType = paymentFrequencyType;
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            CompoundingFrequencyType = compoundingFrequencyType;
            AmortizationFrequencyType = amortizationFrequencyType;
            PeriodicPaymentAmount = periodicPaymentAmount;

        }
    }
}