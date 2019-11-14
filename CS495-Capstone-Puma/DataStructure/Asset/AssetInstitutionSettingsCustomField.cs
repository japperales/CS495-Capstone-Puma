using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset
{
    public class AssetInstitutionSettingsCustomField
    {
        [JsonProperty("CustomFieldId")]
        public long CustomFieldId { get; set; }

        [JsonProperty("FieldName")]
        public string FieldName { get; set; }

        [JsonProperty("LabelName")]
        public string LabelName { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("IsRequired")]
        public bool IsRequired { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonConstructor]
        public AssetInstitutionSettingsCustomField(long customFieldId, string fieldName, string labelName, string value, bool isRequired, DateTimeOffset modifiedDate, string modifiedBy, DateTimeOffset createdDate)
        {
            CustomFieldId = customFieldId;
            FieldName = fieldName;
            LabelName = labelName;
            Value = value;
            IsRequired = isRequired;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            CreatedDate = createdDate;
        }
    }
}