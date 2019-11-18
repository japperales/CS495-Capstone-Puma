using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class InvestmentModelSetting
    {
        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("InvestmentModelId")]
        public long InvestmentModelId { get; set; }

        [JsonProperty("AccountGroupId")]
        public long AccountGroupId { get; set; }

        [JsonProperty("MarketValuePercentage")]
        public long MarketValuePercentage { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public InvestmentModelSetting(long accountId, long investmentModelId, long accountGroupId, long marketValuePercentage, long institutionIdentityRecordId)
        {
            AccountId = accountId;
            InvestmentModelId = investmentModelId;
            AccountGroupId = accountGroupId;
            MarketValuePercentage = marketValuePercentage;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}