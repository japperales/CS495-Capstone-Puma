using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset
{
    public class InterestRate
    {
        [JsonProperty("InterestRateId")]
        public long InterestRateId { get; set; }

        [JsonProperty("Rate")]
        public long Rate { get; set; }

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

        [JsonConstructor]
        public InterestRate(long interestRateId, long rate, DateTimeOffset dateEffectiveFrom, DateTimeOffset dateEffectiveTo, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
        {
            InterestRateId = interestRateId;
            Rate = rate;
            DateEffectiveFrom = dateEffectiveFrom;
            DateEffectiveTo = dateEffectiveTo;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}