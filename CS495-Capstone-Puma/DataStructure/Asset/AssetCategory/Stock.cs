using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset.AssetCategory
{
    public class Stock
    {
        [JsonProperty("IndustryId")]
        public long? IndustryId { get; set; }

        [JsonProperty("ExchangeType")]
        public string ExchangeType { get; set; }

        [JsonProperty("ExchangeTypeName")]
        public string ExchangeTypeName { get; set; }

        [JsonProperty("EarningsPerShareDiluted")]
        public long? EarningsPerShareDiluted { get; set; }

        [JsonProperty("EarningsPerShareBasic")]
        public long? EarningsPerShareBasic { get; set; }

        [JsonProperty("EarningsPerShareEffectiveDate")]
        public DateTimeOffset? EarningsPerShareEffectiveDate { get; set; }

        [JsonProperty("PaymentFrequencyType")]
        public string PaymentFrequencyType { get; set; }

        [JsonProperty("PaymentFrequencyTypeName")]
        public string PaymentFrequencyTypeName { get; set; }

        [JsonProperty("SharesOutstanding")]
        public long? SharesOutstanding { get; set; }

        [JsonProperty("IsIncludedIn13F")]
        public bool? IsIncludedIn13F { get; set; }

        [JsonProperty("IsRestrictedByRule144A")]
        public bool? IsRestrictedByRule144A { get; set; }

        [JsonProperty("CalculatedMarketCapType")]
        public string CalculatedMarketCapType { get; set; }

        [JsonProperty("CalculatedMarketCapTypeName")]
        public string CalculatedMarketCapTypeName { get; set; }
        
        public Stock()
        {
            IndustryId = null;
            ExchangeType = null;
            ExchangeTypeName = null;
            EarningsPerShareDiluted = null;
            EarningsPerShareBasic = null;
            EarningsPerShareEffectiveDate = null;
            PaymentFrequencyType = null;
            PaymentFrequencyTypeName = null;
            SharesOutstanding = null;
            IsIncludedIn13F = null;
            IsRestrictedByRule144A = null;
            CalculatedMarketCapType = null;
            CalculatedMarketCapTypeName = null;
        }
        
        [JsonConstructor]
        public Stock(string exchangeType, long earningsPerShareDiluted, long earningsPerShareBasic, DateTimeOffset earningsPerShareEffectiveDate, string paymentFrequencyType, long sharesOutstanding, bool isIncludedIn13F, bool isRestrictedByRule144A, string calculatedMarketCapType)
        {
            ExchangeType = exchangeType;
            EarningsPerShareDiluted = earningsPerShareDiluted;
            EarningsPerShareBasic = earningsPerShareBasic;
            EarningsPerShareEffectiveDate = earningsPerShareEffectiveDate;
            PaymentFrequencyType = paymentFrequencyType;
            SharesOutstanding = sharesOutstanding;
            IsIncludedIn13F = isIncludedIn13F;
            IsRestrictedByRule144A = isRestrictedByRule144A;
            CalculatedMarketCapType = calculatedMarketCapType;
        }
    }
}