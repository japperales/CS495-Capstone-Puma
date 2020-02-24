using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse.Asset
{
    public class AssetLookupResponse
    {
        [JsonProperty("id")]
        public string id { get; set; }
        
        [JsonProperty("value")]
        public AssetIdentifier value { get; set; }

        public AssetLookupResponse()
        {
            id = "";
            value = new AssetIdentifier();
        }

        [JsonConstructor]
        public AssetLookupResponse(string id, string value)
        {
            this.id = id;

            //Since request returns this JSON Object as a string, JObject is used to Parse it and extract the values
            JObject json = JObject.Parse(value);
            this.value = new AssetIdentifier(json["AssetCode"].ToString(), json["Symbol"].ToString(),
                json["Issue"].ToString(), json["Issuer"].ToString());
        }
        
        public AssetLookupResponse(string id, string assetCode, string symbol, string issue, string issuer)
        {
            this.id = id;
            this.value = new AssetIdentifier(assetCode, symbol, issue, issuer);
        }
    }
}