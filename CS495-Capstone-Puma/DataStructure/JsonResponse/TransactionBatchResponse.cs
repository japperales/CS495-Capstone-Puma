using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
{
    public class TransactionBatchResponse
    {
        [JsonProperty("TransactionBatchId")]
        public int transactionBatchId { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public int institutionIdentityRecordId { get; set; }

        [JsonProperty("Code")]
        public string code { get; set; }

        [JsonProperty("Name")]
        public string name { get; set; }

        [JsonProperty("TransactionStatusType")]
        public string transactionStatusType { get; set; }

        [JsonProperty("IsForError")]
        public bool isForError { get; set; }

        [JsonProperty("CreatedByUserGuid")]
        public string createdByUserGuid { get; set; }


        public TransactionBatchResponse()
        {
            transactionBatchId = -1;
            institutionIdentityRecordId = -1;
            code = "0";
            name = "if you're seeing this, good luck";
            transactionStatusType = "";
            isForError = false;
            createdByUserGuid = "00";
        }

        [JsonConstructor]
        public TransactionBatchResponse(int transactionBatchId, int institutionIdentityRecordId, string code,
            string name, string transactionStatusType, bool isForError, string createdByUserGuid)
        {
            this.transactionBatchId = transactionBatchId;
            this.institutionIdentityRecordId = institutionIdentityRecordId;
            this.code = code;
            this.name = name;
            this.transactionStatusType = transactionStatusType;
            this.isForError = isForError;
            this.createdByUserGuid = createdByUserGuid;
        }
    }
}