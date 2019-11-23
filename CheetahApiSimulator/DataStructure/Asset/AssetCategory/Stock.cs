using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
{
    public class Stock
    {
        [JsonProperty("IndustryId")]
        public long IndustryId { get; set; }

        [JsonProperty("ExchangeType")]
        public string ExchangeType { get; set; }

        [JsonProperty("ExchangeTypeName")]
        public string ExchangeTypeName { get; set; }

        [JsonProperty("EarningsPerShareDiluted")]
        public long EarningsPerShareDiluted { get; set; }

        [JsonProperty("EarningsPerShareBasic")]
        public long EarningsPerShareBasic { get; set; }

        [JsonProperty("EarningsPerShareEffectiveDate")]
        public DateTimeOffset EarningsPerShareEffectiveDate { get; set; }

        [JsonProperty("PaymentFrequencyType")]
        public string PaymentFrequencyType { get; set; }

        [JsonProperty("PaymentFrequencyTypeName")]
        public string PaymentFrequencyTypeName { get; set; }

        [JsonProperty("SharesOutstanding")]
        public long SharesOutstanding { get; set; }

        [JsonProperty("IsIncludedIn13F")]
        public bool IsIncludedIn13F { get; set; }

        [JsonProperty("IsRestrictedByRule144A")]
        public bool IsRestrictedByRule144A { get; set; }

        [JsonProperty("CalculatedMarketCapType")]
        public string CalculatedMarketCapType { get; set; }

        [JsonProperty("CalculatedMarketCapTypeName")]
        public string CalculatedMarketCapTypeName { get; set; }

        [JsonConstructor]
        public Stock(long industryId, string exchangeType, string exchangeTypeName, long earningsPerShareDiluted, long earningsPerShareBasic, DateTimeOffset earningsPerShareEffectiveDate, string paymentFrequencyType, string paymentFrequencyTypeName, long sharesOutstanding, bool isIncludedIn13F, bool isRestrictedByRule144A, string calculatedMarketCapType, string calculatedMarketCapTypeName)
        {
            IndustryId = industryId;
            ExchangeType = exchangeType;
            ExchangeTypeName = exchangeTypeName;
            EarningsPerShareDiluted = earningsPerShareDiluted;
            EarningsPerShareBasic = earningsPerShareBasic;
            EarningsPerShareEffectiveDate = earningsPerShareEffectiveDate;
            PaymentFrequencyType = paymentFrequencyType;
            PaymentFrequencyTypeName = paymentFrequencyTypeName;
            SharesOutstanding = sharesOutstanding;
            IsIncludedIn13F = isIncludedIn13F;
            IsRestrictedByRule144A = isRestrictedByRule144A;
            CalculatedMarketCapType = calculatedMarketCapType;
            CalculatedMarketCapTypeName = calculatedMarketCapTypeName;
        }
    }
}