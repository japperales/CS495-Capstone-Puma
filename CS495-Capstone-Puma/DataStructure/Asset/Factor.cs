using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset
{
    public class Factor
    {
        [JsonProperty("DailyFactorId", NullValueHandling = NullValueHandling.Ignore)]
        public long? DailyFactorId { get; set; }

        [JsonProperty("Factor")]
        public long FactorFactor { get; set; }

        [JsonProperty("DateEffectiveFrom")]
        public DateTimeOffset DateEffectiveFrom { get; set; }

        [JsonProperty("DateEffectiveTo")]
        public DateTimeOffset DateEffectiveTo { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("PoolFactorId", NullValueHandling = NullValueHandling.Ignore)]
        public long? PoolFactorId { get; set; }

        [JsonProperty("PaymentDelay", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentDelay { get; set; }

        [JsonConstructor]
        public Factor(long? dailyFactorId, long factorFactor, DateTimeOffset dateEffectiveFrom, DateTimeOffset dateEffectiveTo, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy, long? poolFactorId, long? paymentDelay)
        {
            DailyFactorId = dailyFactorId;
            FactorFactor = factorFactor;
            DateEffectiveFrom = dateEffectiveFrom;
            DateEffectiveTo = dateEffectiveTo;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            PoolFactorId = poolFactorId;
            PaymentDelay = paymentDelay;
        }
    }
}