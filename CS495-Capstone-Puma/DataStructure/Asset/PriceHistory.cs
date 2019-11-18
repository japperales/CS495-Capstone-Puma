using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset
{
    public class PriceHistory
    {
        [JsonProperty("PriceHistoryId")]
        public long PriceHistoryId { get; set; }

        [JsonProperty("Price")]
        public long Price { get; set; }

        [JsonProperty("Volume")]
        public long Volume { get; set; }

        [JsonProperty("AskPrice")]
        public long AskPrice { get; set; }

        [JsonProperty("BidPrice")]
        public long BidPrice { get; set; }

        [JsonProperty("PricingSourceId")]
        public long PricingSourceId { get; set; }

        [JsonProperty("DateEffectiveFrom")]
        public DateTimeOffset DateEffectiveFrom { get; set; }

        [JsonProperty("DateEffectiveTo")]
        public DateTimeOffset DateEffectiveTo { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonConstructor]
        public PriceHistory(long priceHistoryId, long price, long volume, long askPrice, long bidPrice, long pricingSourceId, DateTimeOffset dateEffectiveFrom, DateTimeOffset dateEffectiveTo, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
        {
            PriceHistoryId = priceHistoryId;
            Price = price;
            Volume = volume;
            AskPrice = askPrice;
            BidPrice = bidPrice;
            PricingSourceId = pricingSourceId;
            DateEffectiveFrom = dateEffectiveFrom;
            DateEffectiveTo = dateEffectiveTo;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}