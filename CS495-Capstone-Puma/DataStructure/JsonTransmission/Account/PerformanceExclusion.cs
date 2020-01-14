using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class PerformanceExclusion
    {
        [JsonProperty("PerformanceExclusionId")]
        public long PerformanceExclusionId { get; set; }

        [JsonProperty("InvestmentSegmentAllocationType")]
        public string InvestmentSegmentAllocationType { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("AccountGroupId")]
        public long AccountGroupId { get; set; }

        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("PortfolioReportCategoryId")]
        public long PortfolioReportCategoryId { get; set; }

        [JsonProperty("IndustryId")]
        public long IndustryId { get; set; }

        [JsonProperty("AssetCategory")]
        public string AssetCategory { get; set; }

        [JsonProperty("AssetPrimaryClassType")]
        public string AssetPrimaryClassType { get; set; }

        [JsonProperty("IsGlobal")]
        public bool IsGlobal { get; set; }

        [JsonProperty("DateBeginning")]
        public DateTimeOffset DateBeginning { get; set; }

        [JsonProperty("DateEnding")]
        public DateTimeOffset DateEnding { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public PerformanceExclusion(long performanceExclusionId, string investmentSegmentAllocationType, long accountId, long accountGroupId, long assetId, long portfolioReportCategoryId, long industryId, string assetCategory, string assetPrimaryClassType, bool isGlobal, DateTimeOffset dateBeginning, DateTimeOffset dateEnding, long institutionIdentityRecordId)
        {
            PerformanceExclusionId = performanceExclusionId;
            InvestmentSegmentAllocationType = investmentSegmentAllocationType;
            AccountId = accountId;
            AccountGroupId = accountGroupId;
            AssetId = assetId;
            PortfolioReportCategoryId = portfolioReportCategoryId;
            IndustryId = industryId;
            AssetCategory = assetCategory;
            AssetPrimaryClassType = assetPrimaryClassType;
            IsGlobal = isGlobal;
            DateBeginning = dateBeginning;
            DateEnding = dateEnding;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}