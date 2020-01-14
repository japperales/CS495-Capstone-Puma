using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class InvestmentModelSetting
    {
        [JsonProperty("InvestmentModelId")]
        public long InvestmentModelId { get; set; }

        [JsonProperty("AccountGroupId")]
        public long AccountGroupId { get; set; }

        [JsonProperty("MarketValuePercentage")]
        public long MarketValuePercentage { get; set; }

        
        [JsonConstructor]
        public InvestmentModelSetting(long investmentModelId, long accountGroupId, long marketValuePercentage)
        {
            InvestmentModelId = investmentModelId;
            AccountGroupId = accountGroupId;
            MarketValuePercentage = marketValuePercentage;
        }
    }
}