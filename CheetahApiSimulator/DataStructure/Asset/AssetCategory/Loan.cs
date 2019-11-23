using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
{
    public class Loan
    {
        [JsonProperty("DateOfIssue")]
        public DateTimeOffset DateOfIssue { get; set; }

        [JsonProperty("DateOfMaturity")]
        public DateTimeOffset DateOfMaturity { get; set; }

        [JsonProperty("DateOfFirstPayment")]
        public DateTimeOffset DateOfFirstPayment { get; set; }

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
        public long IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long IncomePaymentDay { get; set; }

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
        public long DepositoryIdentityRecordId { get; set; }

        [JsonProperty("LenderIdentityRecordId")]
        public long LenderIdentityRecordId { get; set; }

        [JsonProperty("BorrowerIdentityRecordId")]
        public long BorrowerIdentityRecordId { get; set; }

        [JsonProperty("PeriodicPaymentAmount")]
        public long PeriodicPaymentAmount { get; set; }

        [JsonProperty("ExcludeFromDelinquencyReporting")]
        public bool ExcludeFromDelinquencyReporting { get; set; }

        [JsonProperty("DateExcludeFromDelinquencyExpiration")]
        public DateTimeOffset DateExcludeFromDelinquencyExpiration { get; set; }

        [JsonConstructor]
        public Loan(DateTimeOffset dateOfIssue, DateTimeOffset dateOfMaturity, DateTimeOffset dateOfFirstPayment, string oddLastCouponType, string oddLastCouponTypeName, string paymentFrequencyType, string paymentFrequencyTypeName, string incomePaymentFrequencyType, string incomePaymentFrequencyTypeName, long incomePaymentMonth, long incomePaymentDay, string compoundingFrequencyType, string compoundingFrequencyTypeName, string amortizationFrequencyType, string amortizationFrequencyTypeName, string accrualMethodType, string accrualMethodTypeName, long depositoryIdentityRecordId, long lenderIdentityRecordId, long borrowerIdentityRecordId, long periodicPaymentAmount, bool excludeFromDelinquencyReporting, DateTimeOffset dateExcludeFromDelinquencyExpiration)
        {
            DateOfIssue = dateOfIssue;
            DateOfMaturity = dateOfMaturity;
            DateOfFirstPayment = dateOfFirstPayment;
            OddLastCouponType = oddLastCouponType;
            OddLastCouponTypeName = oddLastCouponTypeName;
            PaymentFrequencyType = paymentFrequencyType;
            PaymentFrequencyTypeName = paymentFrequencyTypeName;
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentFrequencyTypeName = incomePaymentFrequencyTypeName;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            CompoundingFrequencyType = compoundingFrequencyType;
            CompoundingFrequencyTypeName = compoundingFrequencyTypeName;
            AmortizationFrequencyType = amortizationFrequencyType;
            AmortizationFrequencyTypeName = amortizationFrequencyTypeName;
            AccrualMethodType = accrualMethodType;
            AccrualMethodTypeName = accrualMethodTypeName;
            DepositoryIdentityRecordId = depositoryIdentityRecordId;
            LenderIdentityRecordId = lenderIdentityRecordId;
            BorrowerIdentityRecordId = borrowerIdentityRecordId;
            PeriodicPaymentAmount = periodicPaymentAmount;
            ExcludeFromDelinquencyReporting = excludeFromDelinquencyReporting;
            DateExcludeFromDelinquencyExpiration = dateExcludeFromDelinquencyExpiration;
        }
    }
}