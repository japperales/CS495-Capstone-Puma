using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse.Asset
{
    public class AssetInput
    {
        [JsonProperty("AssetIdentifier")]
        public AssetIdentifier assetIdentifier { get; set; }
        
        [JsonProperty("Units")]
        public int units { get; set; }

        public AssetInput()
        {
            assetIdentifier = new AssetIdentifier();
            units = 0;
        }

        [JsonConstructor]
        public AssetInput(AssetIdentifier assetIdentifier, int units)
        {
            this.assetIdentifier = assetIdentifier;
            this.units = units;
        }
    }
}