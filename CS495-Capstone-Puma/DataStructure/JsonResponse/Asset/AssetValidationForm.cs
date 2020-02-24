using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse.Asset
{
    public class AssetValidationForm
    {
        
            [JsonProperty("id")]
            public string id { get; set; }
        
            [JsonProperty("value")]
            public AssetIdentifier value { get; set; }

            public AssetValidationForm()
            {
                id = "";
                value = new AssetIdentifier();
            }
            
            [JsonConstructor]
            public AssetValidationForm(string id, string assetCode, string symbol, string issue, string issuer)
            {
                this.id = id;
                this.value = new AssetIdentifier(assetCode, symbol, issue, issuer);
            }
        
    }
}