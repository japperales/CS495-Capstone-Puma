using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonRequest
{
    public class TransactionBatchRequest
    {
        [JsonProperty("InstitutionRecordId")]
        public int institutionRecordId { get; }
        
        [JsonProperty("Code")]
        public string code { get; }
        
        [JsonProperty("Name")]
        public string name { get; }

        public TransactionBatchRequest()
        {
            institutionRecordId = 1;
            code = "123456789";
            name = "PumaApi";
        }
    }
}