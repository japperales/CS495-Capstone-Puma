using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
{
    public class MutualFund
    {
        [JsonProperty("IncomePaymentFrequencyType")]
        public string IncomePaymentFrequencyType { get; set; }

        [JsonProperty("IncomePaymentFrequencyTypeName")]
        public string IncomePaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentMonth")]
        public long IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long IncomePaymentDay { get; set; }

        [JsonProperty("UseDailyFactor")]
        public bool UseDailyFactor { get; set; }

        [JsonProperty("AccrualMethodType")]
        public string AccrualMethodType { get; set; }

        [JsonProperty("AccrualMethodTypeName")]
        public string AccrualMethodTypeName { get; set; }

        [JsonProperty("ExchangeType")]
        public string ExchangeType { get; set; }

        [JsonProperty("ExchangeTypeName")]
        public string ExchangeTypeName { get; set; }

        [JsonProperty("EarningsPerShareDiluted")]
        public long EarningsPerShareDiluted { get; set; }

        [JsonProperty("FundFamilyId")]
        public long FundFamilyId { get; set; }

        [JsonProperty("FundCategoryId")]
        public long FundCategoryId { get; set; }

        [JsonProperty("FundNumber")]
        public string FundNumber { get; set; }

        [JsonProperty("FundStatusType")]
        public string FundStatusType { get; set; }

        [JsonProperty("FundStatusTypeName")]
        public string FundStatusTypeName { get; set; }

        [JsonProperty("ShortTermRedemptionFeePercent")]
        public long ShortTermRedemptionFeePercent { get; set; }

        [JsonProperty("ShortTermHoldingPeriod")]
        public long ShortTermHoldingPeriod { get; set; }

        [JsonConstructor]
        public MutualFund(string incomePaymentFrequencyType, string incomePaymentFrequencyTypeName, long incomePaymentMonth, long incomePaymentDay, bool useDailyFactor, string accrualMethodType, string accrualMethodTypeName, string exchangeType, string exchangeTypeName, long earningsPerShareDiluted, long fundFamilyId, long fundCategoryId, string fundNumber, string fundStatusType, string fundStatusTypeName, long shortTermRedemptionFeePercent, long shortTermHoldingPeriod)
        {
            IncomePaymentFrequencyType = incomePaymentFrequencyType;
            IncomePaymentFrequencyTypeName = incomePaymentFrequencyTypeName;
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            UseDailyFactor = useDailyFactor;
            AccrualMethodType = accrualMethodType;
            AccrualMethodTypeName = accrualMethodTypeName;
            ExchangeType = exchangeType;
            ExchangeTypeName = exchangeTypeName;
            EarningsPerShareDiluted = earningsPerShareDiluted;
            FundFamilyId = fundFamilyId;
            FundCategoryId = fundCategoryId;
            FundNumber = fundNumber;
            FundStatusType = fundStatusType;
            FundStatusTypeName = fundStatusTypeName;
            ShortTermRedemptionFeePercent = shortTermRedemptionFeePercent;
            ShortTermHoldingPeriod = shortTermHoldingPeriod;
        }
    }
}