using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse.Asset
{
    public class AssetIdentifier
    {
        [JsonProperty("AssetCode")]
        public string assetCode { get; set; }
        
        [JsonProperty("Symbol")]
        public string symbol { get; set; }
        
        [JsonProperty("Issue")]
        public string issue { get; set; }

        [JsonProperty("Issuer")]
        public string issuer { get; set; }

        public AssetIdentifier()
        {
            assetCode = "";
            symbol = "";
            issue = "";
            issuer = "";
        }

        [JsonConstructor]
        public AssetIdentifier(string assetCode, string symbol, string issue, string issuer)
        {
            this.assetCode = assetCode;
            this.symbol = symbol;
            this.issue = issue;
            this.issuer = issuer;
        }
        
        public class AssetEqualityComparer : IEqualityComparer<AssetIdentifier>
        {
            public bool Equals(AssetIdentifier x, AssetIdentifier y)
            {
                return (x.symbol == y.symbol);
            }

            public int GetHashCode(AssetIdentifier obj)
            {
                string combined = obj.symbol;
                return obj.symbol.GetHashCode();
            }
        }
    }
}