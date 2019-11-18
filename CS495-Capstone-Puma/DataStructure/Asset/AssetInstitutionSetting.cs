using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset
{
    public class AssetInstitutionSetting
    {
        [JsonProperty("AssetInstitutionSettingsId")]
        public long AssetInstitutionSettingsId { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonProperty("OverridePortfolioReportCategoryId")]
        public long OverridePortfolioReportCategoryId { get; set; }

        [JsonProperty("OverrideIndustryId")]
        public long OverrideIndustryId { get; set; }

        [JsonProperty("MarketCapType")]
        public string MarketCapType { get; set; }

        [JsonProperty("MarketCapTypeName")]
        public string MarketCapTypeName { get; set; }

        [JsonProperty("UnitDecimal")]
        public long UnitDecimal { get; set; }

        [JsonProperty("ApprovedListRuleType")]
        public string ApprovedListRuleType { get; set; }

        [JsonProperty("ApprovedListRuleTypeName")]
        public string ApprovedListRuleTypeName { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("AssetInstitutionSettingsCustomFields")]
        public List<AssetInstitutionSettingsCustomField> AssetInstitutionSettingsCustomFields { get; set; }

        [JsonConstructor]
        public AssetInstitutionSetting(long assetInstitutionSettingsId, long institutionIdentityRecordId, long overridePortfolioReportCategoryId, long overrideIndustryId, string marketCapType, string marketCapTypeName, long unitDecimal, string approvedListRuleType, string approvedListRuleTypeName, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy, List<AssetInstitutionSettingsCustomField> assetInstitutionSettingsCustomFields)
        {
            AssetInstitutionSettingsId = assetInstitutionSettingsId;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
            OverridePortfolioReportCategoryId = overridePortfolioReportCategoryId;
            OverrideIndustryId = overrideIndustryId;
            MarketCapType = marketCapType;
            MarketCapTypeName = marketCapTypeName;
            UnitDecimal = unitDecimal;
            ApprovedListRuleType = approvedListRuleType;
            ApprovedListRuleTypeName = approvedListRuleTypeName;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            AssetInstitutionSettingsCustomFields = assetInstitutionSettingsCustomFields;
        }
    }
}