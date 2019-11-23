using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset
{
    public class QualityRatingHistory
    {
        [JsonProperty("QualityRatingHistoryId")]
        public long QualityRatingHistoryId { get; set; }

        [JsonProperty("QualityRatingSourceId")]
        public long QualityRatingSourceId { get; set; }

        [JsonProperty("QualityRating")]
        public string QualityRating { get; set; }

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
        public QualityRatingHistory(long qualityRatingHistoryId, long qualityRatingSourceId, string qualityRating, DateTimeOffset dateEffectiveFrom, DateTimeOffset dateEffectiveTo, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
        {
            QualityRatingHistoryId = qualityRatingHistoryId;
            QualityRatingSourceId = qualityRatingSourceId;
            QualityRating = qualityRating;
            DateEffectiveFrom = dateEffectiveFrom;
            DateEffectiveTo = dateEffectiveTo;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}