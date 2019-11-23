using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset.AssetCategory
{
    public class Option
    {
        [JsonProperty("IndustryId")]
        public long IndustryId { get; set; }

        [JsonProperty("ExchangeType")]
        public string ExchangeType { get; set; }

        [JsonProperty("ExchangeTypeName")]
        public string ExchangeTypeName { get; set; }

        [JsonProperty("DateOfExpiration")]
        public DateTimeOffset DateOfExpiration { get; set; }

        [JsonProperty("AssociatedAssetId")]
        public long AssociatedAssetId { get; set; }

        [JsonProperty("AssociatedAssetCode")]
        public string AssociatedAssetCode { get; set; }

        [JsonProperty("StrikePriceAmount")]
        public long StrikePriceAmount { get; set; }

        [JsonConstructor]
        public Option(long industryId, string exchangeType, string exchangeTypeName, DateTimeOffset dateOfExpiration, long associatedAssetId, string associatedAssetCode, long strikePriceAmount)
        {
            IndustryId = industryId;
            ExchangeType = exchangeType;
            ExchangeTypeName = exchangeTypeName;
            DateOfExpiration = dateOfExpiration;
            AssociatedAssetId = associatedAssetId;
            AssociatedAssetCode = associatedAssetCode;
            StrikePriceAmount = strikePriceAmount;
        }
    }
}