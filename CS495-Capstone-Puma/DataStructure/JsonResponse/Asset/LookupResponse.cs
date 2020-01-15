using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse.Asset
{
    public class LookupResponse
    {
        [JsonProperty("LookupServiceType")]
        public string lookupServiceType { get; set; }
        
        [JsonProperty("Items")]
        public List<AssetLookupResponse> items { get; set; }

        public LookupResponse()
        {
            lookupServiceType = "";
            items = new List<AssetLookupResponse>();
        }

        public LookupResponse(string lookupServiceType, List<AssetLookupResponse> items)
        {
            this.lookupServiceType = lookupServiceType;
            this.items = items;
        }
    }
}