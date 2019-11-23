using System;
using System.Collections.Generic;
using CheetahApiSimulator.DataStructure.Asset.AssetCategory;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Asset
{
    public class Asset
    {
        [JsonProperty("AssetId")] public int AssetId { get; set; }

        [JsonProperty("AssetCode")] public string AssetCode { get; set; }

        [JsonProperty("AssetCodeType")] public string AssetCodeType { get; set; }

        [JsonProperty("AssetCodeTypeName")] public string AssetCodeTypeName { get; set; }

        [JsonProperty("PortfolioReportCategoryId")]
        public long? PortfolioReportCategoryId { get; set; }

        [JsonProperty("AssetCategory")] public string AssetCategory { get; set; }

        [JsonProperty("AssetCategoryDisplayName")]
        public string AssetCategoryDisplayName { get; set; }

        [JsonProperty("Symbol")] public string Symbol { get; set; }

        [JsonProperty("Issue")] public string Issue { get; set; }

        [JsonProperty("Issuer")] public string Issuer { get; set; }

        [JsonProperty("IssueStatusType")] public string IssueStatusType { get; set; }

        [JsonProperty("IssueStatusTypeName")] public string IssueStatusTypeName { get; set; }

        [JsonProperty("StateProvince")] public string StateProvince { get; set; }

        [JsonProperty("StateProvinceAbbreviation")]
        public string StateProvinceAbbreviation { get; set; }

        [JsonProperty("Country")] public string Country { get; set; }

        [JsonProperty("CountryName")] public string CountryName { get; set; }

        [JsonProperty("DomainModelClass")] public string DomainModelClass { get; set; }

        [JsonProperty("DomainModelClassName")] public string DomainModelClassName { get; set; }

        [JsonProperty("TradeWhenInstitutionOpen")]
        public bool TradeWhenInstitutionOpen { get; set; }

        [JsonProperty("UpdateFromInterface")] public bool UpdateFromInterface { get; set; }

        [JsonProperty("IraHardToValueType")] public string IraHardToValueType { get; set; }

        [JsonProperty("IraHardToValueTypeName")]
        public string IraHardToValueTypeName { get; set; }

        [JsonProperty("IsActive")] public bool IsActive { get; set; }

        [JsonProperty("CreatedDate")] public DateTimeOffset? CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")] public DateTimeOffset? ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")] public string ModifiedBy { get; set; }

        [JsonProperty("Stock")] public Stock Stock { get; set; }

        [JsonProperty("Bond")] public Bond Bond { get; set; }

        [JsonProperty("CashEquivalent")] public CashEquivalent CashEquivalent { get; set; }

        [JsonProperty("CertificateOfDeposit")] public CashEquivalent CertificateOfDeposit { get; set; }

        [JsonProperty("MutualFund")] public MutualFund MutualFund { get; set; }

        [JsonProperty("OtherAsset")] public CashEquivalent OtherAsset { get; set; }

        [JsonProperty("Option")] public Option Option { get; set; }

        [JsonProperty("Property")] public Property Property { get; set; }

        [JsonProperty("Loan")] public Loan Loan { get; set; }

        [JsonProperty("DailyFactors")] public List<Factor> DailyFactors { get; set; }

        [JsonProperty("DividendEvents")] public List<DividendEvent> DividendEvents { get; set; }

        [JsonProperty("InterestRates")] public List<InterestRate> InterestRates { get; set; }

        [JsonProperty("PoolFactors")] public List<Factor> PoolFactors { get; set; }

        [JsonProperty("PriceHistories")] public List<PriceHistory> PriceHistories { get; set; }

        [JsonProperty("QualityRatingHistories")]
        public List<QualityRatingHistory> QualityRatingHistories { get; set; }

        [JsonProperty("AssetInstitutionSettings")]
        public List<AssetInstitutionSetting> AssetInstitutionSettings { get; set; }

        public Asset()
        {
            defaultValues();
        }

        public Asset(int assetId, string assetCode, Bond bond)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            Bond = bond;
        }
        
        public Asset(int assetId, string assetCode, Stock stock)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            Stock = stock;
        }
        
        public Asset(int assetId, string assetCode, Loan loan)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            Loan = loan;
        }
        
        public Asset(int assetId, string assetCode, MutualFund mutualFund)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            MutualFund = mutualFund;
        }
        
        public Asset(int assetId, string assetCode, Property property)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            Property = property;
        }
        
        public Asset(int assetId, string assetCode, CashEquivalent cashEquivalent)
        {
            defaultValues();
            AssetId = assetId;
            AssetCode = assetCode;
            CashEquivalent = cashEquivalent;
        }

        private void defaultValues()
        {
            AssetId = 0;
            AssetCode = null;
            AssetCodeType = null;
            AssetCodeTypeName = null;
            PortfolioReportCategoryId = null;
            AssetCategory = null;
            AssetCategoryDisplayName = null;
            Symbol = null;
            Issue = null;
            Issuer = null;
            IssueStatusType = null;
            IssueStatusTypeName = null;
            StateProvince = null;
            StateProvinceAbbreviation = null;
            Country = null;
            CountryName = null;
            DomainModelClass = null;
            DomainModelClassName = null;
            TradeWhenInstitutionOpen = false;
            UpdateFromInterface = false;
            IraHardToValueType = null;
            IraHardToValueTypeName = null;
            IsActive = true;
            CreatedDate = null;
            ModifiedDate = null;
            ModifiedBy = null;
            Stock = null;
            Bond = null;
            CashEquivalent = null;
            CertificateOfDeposit = null;
            MutualFund = null;
            OtherAsset = null;
            Option = null;
            Property = null;
            Loan = null;
            DailyFactors = null;
            DividendEvents = null;
            InterestRates = null;
            PoolFactors = null;
            PriceHistories = null;
            QualityRatingHistories = null;
            AssetInstitutionSettings = null;
        }
    }
}