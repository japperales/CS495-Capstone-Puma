using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Asset
{
    public class Asset
    {
        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("AssetCode")]
        public string AssetCode { get; set; }

        [JsonProperty("AssetCodeType")]
        public string AssetCodeType { get; set; }

        [JsonProperty("AssetCodeTypeName")]
        public string AssetCodeTypeName { get; set; }

        [JsonProperty("PortfolioReportCategoryId")]
        public long PortfolioReportCategoryId { get; set; }

        [JsonProperty("AssetCategory")]
        public string AssetCategory { get; set; }

        [JsonProperty("AssetCategoryDisplayName")]
        public string AssetCategoryDisplayName { get; set; }

        [JsonProperty("Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("Issue")]
        public string Issue { get; set; }

        [JsonProperty("Issuer")]
        public string Issuer { get; set; }

        [JsonProperty("IssueStatusType")]
        public string IssueStatusType { get; set; }

        [JsonProperty("IssueStatusTypeName")]
        public string IssueStatusTypeName { get; set; }

        [JsonProperty("StateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("StateProvinceAbbreviation")]
        public string StateProvinceAbbreviation { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }

        [JsonProperty("DomainModelClass")]
        public string DomainModelClass { get; set; }

        [JsonProperty("DomainModelClassName")]
        public string DomainModelClassName { get; set; }

        [JsonProperty("TradeWhenInstitutionOpen")]
        public bool TradeWhenInstitutionOpen { get; set; }

        [JsonProperty("UpdateFromInterface")]
        public bool UpdateFromInterface { get; set; }

        [JsonProperty("IraHardToValueType")]
        public string IraHardToValueType { get; set; }

        [JsonProperty("IraHardToValueTypeName")]
        public string IraHardToValueTypeName { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("Stock")]
        public Stock Stock { get; set; }

        [JsonProperty("Bond")]
        public Bond Bond { get; set; }

        [JsonProperty("CashEquivalent")]
        public CashEquivalent CashEquivalent { get; set; }

        [JsonProperty("CertificateOfDeposit")]
        public CashEquivalent CertificateOfDeposit { get; set; }

        [JsonProperty("MutualFund")]
        public MutualFund MutualFund { get; set; }

        [JsonProperty("OtherAsset")]
        public CashEquivalent OtherAsset { get; set; }

        [JsonProperty("Option")]
        public Option Option { get; set; }

        [JsonProperty("Property")]
        public Property Property { get; set; }

        [JsonProperty("Loan")]
        public Loan Loan { get; set; }

        [JsonProperty("DailyFactors")]
        public List<Factor> DailyFactors { get; set; }

        [JsonProperty("DividendEvents")]
        public List<DividendEvent> DividendEvents { get; set; }

        [JsonProperty("InterestRates")]
        public List<InterestRate> InterestRates { get; set; }

        [JsonProperty("PoolFactors")]
        public List<Factor> PoolFactors { get; set; }

        [JsonProperty("PriceHistories")]
        public List<PriceHistory> PriceHistories { get; set; }

        [JsonProperty("QualityRatingHistories")]
        public List<QualityRatingHistory> QualityRatingHistories { get; set; }

        [JsonProperty("AssetInstitutionSettings")]
        public List<AssetInstitutionSetting> AssetInstitutionSettings { get; set; }

        [JsonConstructor]
        public Asset(long assetId, string assetCode, string assetCodeType, string assetCodeTypeName, long portfolioReportCategoryId, string assetCategory, string assetCategoryDisplayName, string symbol, string issue, string issuer, string issueStatusType, string issueStatusTypeName, string stateProvince, string stateProvinceAbbreviation, string country, string countryName, string domainModelClass, string domainModelClassName, bool tradeWhenInstitutionOpen, bool updateFromInterface, string iraHardToValueType, string iraHardToValueTypeName, bool isActive, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy, Stock stock, Bond bond, CashEquivalent cashEquivalent, CashEquivalent certificateOfDeposit, MutualFund mutualFund, CashEquivalent otherAsset, Option option, Property property, Loan loan, List<Factor> dailyFactors, List<DividendEvent> dividendEvents, List<InterestRate> interestRates, List<Factor> poolFactors, List<PriceHistory> priceHistories, List<QualityRatingHistory> qualityRatingHistories, List<AssetInstitutionSetting> assetInstitutionSettings)
        {
            AssetId = assetId;
            AssetCode = assetCode;
            AssetCodeType = assetCodeType;
            AssetCodeTypeName = assetCodeTypeName;
            PortfolioReportCategoryId = portfolioReportCategoryId;
            AssetCategory = assetCategory;
            AssetCategoryDisplayName = assetCategoryDisplayName;
            Symbol = symbol;
            Issue = issue;
            Issuer = issuer;
            IssueStatusType = issueStatusType;
            IssueStatusTypeName = issueStatusTypeName;
            StateProvince = stateProvince;
            StateProvinceAbbreviation = stateProvinceAbbreviation;
            Country = country;
            CountryName = countryName;
            DomainModelClass = domainModelClass;
            DomainModelClassName = domainModelClassName;
            TradeWhenInstitutionOpen = tradeWhenInstitutionOpen;
            UpdateFromInterface = updateFromInterface;
            IraHardToValueType = iraHardToValueType;
            IraHardToValueTypeName = iraHardToValueTypeName;
            IsActive = isActive;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            Stock = stock;
            Bond = bond;
            CashEquivalent = cashEquivalent;
            CertificateOfDeposit = certificateOfDeposit;
            MutualFund = mutualFund;
            OtherAsset = otherAsset;
            Option = option;
            Property = property;
            Loan = loan;
            DailyFactors = dailyFactors;
            DividendEvents = dividendEvents;
            InterestRates = interestRates;
            PoolFactors = poolFactors;
            PriceHistories = priceHistories;
            QualityRatingHistories = qualityRatingHistories;
            AssetInstitutionSettings = assetInstitutionSettings;
        }
    }
}