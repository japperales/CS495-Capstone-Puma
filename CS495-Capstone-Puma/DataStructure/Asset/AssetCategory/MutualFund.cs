using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset.AssetCategory
{
    public class MutualFund
    {
        [JsonProperty("IncomePaymentFrequencyType")]
        public string IncomePaymentFrequencyType { get; set; }

        [JsonProperty("IncomePaymentFrequencyTypeName")]
        public string IncomePaymentFrequencyTypeName { get; set; }

        [JsonProperty("IncomePaymentMonth")]
        public long? IncomePaymentMonth { get; set; }

        [JsonProperty("IncomePaymentDay")]
        public long? IncomePaymentDay { get; set; }

        [JsonProperty("UseDailyFactor")]
        public bool? UseDailyFactor { get; set; }

        [JsonProperty("AccrualMethodType")]
        public string AccrualMethodType { get; set; }

        [JsonProperty("AccrualMethodTypeName")]
        public string AccrualMethodTypeName { get; set; }

        [JsonProperty("ExchangeType")]
        public string ExchangeType { get; set; }

        [JsonProperty("ExchangeTypeName")]
        public string ExchangeTypeName { get; set; }

        [JsonProperty("EarningsPerShareDiluted")]
        public long? EarningsPerShareDiluted { get; set; }

        [JsonProperty("FundFamilyId")]
        public long? FundFamilyId { get; set; }

        [JsonProperty("FundCategoryId")]
        public long? FundCategoryId { get; set; }

        [JsonProperty("FundNumber")]
        public string FundNumber { get; set; }

        [JsonProperty("FundStatusType")]
        public string FundStatusType { get; set; }

        [JsonProperty("FundStatusTypeName")]
        public string FundStatusTypeName { get; set; }

        [JsonProperty("ShortTermRedemptionFeePercent")]
        public long? ShortTermRedemptionFeePercent { get; set; }

        [JsonProperty("ShortTermHoldingPeriod")]
        public long? ShortTermHoldingPeriod { get; set; }
        
        public MutualFund()
        {
            IncomePaymentFrequencyType = null;
            IncomePaymentFrequencyTypeName = null;
            IncomePaymentMonth = null;
            IncomePaymentDay = null;
            UseDailyFactor = null;
            AccrualMethodType = null;
            AccrualMethodTypeName = null;
            ExchangeType = null;
            ExchangeTypeName = null;
            EarningsPerShareDiluted = null;
            FundFamilyId = null;
            FundCategoryId = null;
            FundNumber = null;
            FundStatusType = null;
            FundStatusTypeName = null;
            ShortTermRedemptionFeePercent = null;
            ShortTermHoldingPeriod = null;
        }

        [JsonConstructor]
        public MutualFund(int incomePaymentMonth, int incomePaymentDay, bool useDailyFactor, string accrualMethodType,
            string exchangeType,
            int earningsPerShareDiluted, int fundFamilyId, int fundCategoryId, string fundNumber, string fundStatusType,
            int shortTermRedemptionFeePercent,
            int shortTermHoldingPeriod)
        {
            IncomePaymentMonth = incomePaymentMonth;
            IncomePaymentDay = incomePaymentDay;
            UseDailyFactor = useDailyFactor;
            AccrualMethodType = accrualMethodType;
            ExchangeType = exchangeType;
            EarningsPerShareDiluted = earningsPerShareDiluted;
            FundFamilyId = fundFamilyId;
            FundCategoryId = fundCategoryId;
            FundNumber = fundNumber;
            FundStatusType = fundStatusType;
            ShortTermRedemptionFeePercent = shortTermRedemptionFeePercent;
            ShortTermHoldingPeriod = shortTermHoldingPeriod;
        }
    }
}