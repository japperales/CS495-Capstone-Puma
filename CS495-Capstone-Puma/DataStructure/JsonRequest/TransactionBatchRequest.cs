using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonRequest
{
    public class TransactionBatchRequest
    {
        [JsonProperty("InstitutionIdentityRecordId")]
        public int institutionRecordId { get; }
        
        [JsonProperty("Code")]
        public string code { get; }
        
        [JsonProperty("Name")]
        public string name { get; }

        public TransactionBatchRequest()
        {
            institutionRecordId = 1;
            code = "0";
            name = "PumaApi";
        }

        [JsonConstructor]
        public TransactionBatchRequest(int institutionRecordId, string code, string name)
        {
            this.institutionRecordId = institutionRecordId;
            this.code = code;
            this.name = name;
        }
    }
}