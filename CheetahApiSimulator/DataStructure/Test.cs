using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure
{
    public class Test
    {
        private int identityRecordId { get; set; }
        private string displayName { get; set; }
        
        [JsonConstructor]
        public Test(int identityRecordId, string displayName)
        {
            this.identityRecordId = identityRecordId;
            this.displayName = displayName;
        }
    }
}