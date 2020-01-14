using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
{
    public class NameAndAddressesResponse
    {
        [JsonProperty("IdentityRecordId")] 
        public int IdentityRecordId { get; set; }
        
        [JsonProperty("DisplayName")] 
        public string DisplayName { get; set; }
        
        [JsonProperty("Link")] 
        public string Link { get; set; }

        public NameAndAddressesResponse()
        {
            IdentityRecordId = -1;
            DisplayName = "";
            Link = "";
        }

        [JsonConstructor]
        public NameAndAddressesResponse(int identityRecordId, string displayName, string link)
        {
            IdentityRecordId = identityRecordId;
            DisplayName = displayName;
            Link = link;
        }
    }
}