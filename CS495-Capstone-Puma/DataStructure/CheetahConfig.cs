using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class CheetahConfig
    {
        [JsonProperty("x-api-key")]
        public string XApiKey { get; set; }
        
        [JsonProperty("apiUrlRoot")]
        public string ApiUrlRoot { get; set; }

        public CheetahConfig()
        {
            XApiKey = "";
            ApiUrlRoot = "";
        }

        [JsonConstructor]
        public CheetahConfig(string xApiKey, string apiUrlRoot)
        {
            XApiKey = xApiKey;
            ApiUrlRoot = apiUrlRoot;
        }
    }
}