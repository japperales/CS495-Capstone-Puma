using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Account
{
    public class AccountSettings
    {
        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("InvestmentObjectiveId")]
        public long InvestmentObjectiveId { get; set; }

        [JsonProperty("InvestmentReviewFrequencyType")]
        public string InvestmentReviewFrequencyType { get; set; }

        [JsonProperty("InvestmentReviewFrequencyMonthOffset")]
        public long InvestmentReviewFrequencyMonthOffset { get; set; }

        [JsonProperty("AdministrativeReviewFrequencyType")]
        public string AdministrativeReviewFrequencyType { get; set; }

        [JsonProperty("AdministrativeReviewFrequencyMonthOffset")]
        public long AdministrativeReviewFrequencyMonthOffset { get; set; }

        [JsonProperty("IsPurchaseRestricted")]
        public bool IsPurchaseRestricted { get; set; }

        [JsonProperty("IsSalesRestricted")]
        public bool IsSalesRestricted { get; set; }

        [JsonProperty("DateOfRestrictionExpiration")]
        public DateTimeOffset DateOfRestrictionExpiration { get; set; }

        [JsonProperty("IsMutualFundPurchaseRestricted")]
        public bool IsMutualFundPurchaseRestricted { get; set; }

        [JsonProperty("IsMutualFundSalesRestricted")]
        public bool IsMutualFundSalesRestricted { get; set; }

        [JsonProperty("DateOfMutualFundRestrictionExpiration")]
        public DateTimeOffset DateOfMutualFundRestrictionExpiration { get; set; }

        [JsonProperty("IsInternalReportRecipient")]
        public bool IsInternalReportRecipient { get; set; }

        [JsonProperty("ShowExtraordinaryFeeSummary")]
        public bool ShowExtraordinaryFeeSummary { get; set; }

        [JsonProperty("ReinvestOptionType")]
        public string ReinvestOptionType { get; set; }

        [JsonProperty("SpecificPowers")]
        public string SpecificPowers { get; set; }

        [JsonProperty("DistributionOfPrincipal")]
        public string DistributionOfPrincipal { get; set; }

        [JsonProperty("IsPrincipalOnly")]
        public bool IsPrincipalOnly { get; set; }

        [JsonProperty("CapacityCategoryId")]
        public long CapacityCategoryId { get; set; }

        [JsonProperty("InvestmentPowerTypeId")]
        public long InvestmentPowerTypeId { get; set; }

        [JsonProperty("ProxyInvestmentPowerType")]
        public string ProxyInvestmentPowerType { get; set; }

        [JsonProperty("LongTermLossCarryForwardAmount")]
        public long LongTermLossCarryForwardAmount { get; set; }

        [JsonProperty("ShortTermLossCarryForwardAmount")]
        public long ShortTermLossCarryForwardAmount { get; set; }

        [JsonProperty("DateCarryForward")]
        public DateTimeOffset DateCarryForward { get; set; }

        [JsonProperty("TaxationType")]
        public string TaxationType { get; set; }

        [JsonProperty("DateTaxYearEnd")]
        public DateTimeOffset DateTaxYearEnd { get; set; }

        [JsonProperty("CapitalGainRatePercent")]
        public long CapitalGainRatePercent { get; set; }

        [JsonProperty("TaxInterfaceType")]
        public string TaxInterfaceType { get; set; }

        [JsonProperty("Tax1099LevelType")]
        public string Tax1099LevelType { get; set; }

        [JsonProperty("IsOverdraftAllowed")]
        public bool IsOverdraftAllowed { get; set; }

        [JsonProperty("IsNetCashOverdraft")]
        public bool IsNetCashOverdraft { get; set; }

        [JsonProperty("SweepSetupId")]
        public long SweepSetupId { get; set; }

        [JsonProperty("CashAutoTransferType")]
        public string CashAutoTransferType { get; set; }

        [JsonProperty("PrincipalReserveAmount")]
        public long PrincipalReserveAmount { get; set; }

        [JsonProperty("IncomeReserveAmount")]
        public long IncomeReserveAmount { get; set; }

        [JsonProperty("SweepPrincipalReserveAmount")]
        public long SweepPrincipalReserveAmount { get; set; }

        [JsonProperty("SweepIncomeReserveAmount")]
        public long SweepIncomeReserveAmount { get; set; }

        [JsonProperty("TaxLotHarvestingType")]
        public string TaxLotHarvestingType { get; set; }

        [JsonProperty("AmortizationType")]
        public string AmortizationType { get; set; }

        [JsonProperty("ComptrollerType")]
        public string ComptrollerType { get; set; }

        [JsonProperty("CashDescription")]
        public string CashDescription { get; set; }

        [JsonProperty("PerformanceIndexSettingId")]
        public long PerformanceIndexSettingId { get; set; }

        [JsonProperty("PerformanceExclusions")]
        public List<PerformanceExclusion> PerformanceExclusions { get; set; }

        [JsonProperty("LegacyPriorYearEndMarketValue")]
        public long LegacyPriorYearEndMarketValue { get; set; }

        [JsonProperty("LegacyYtdContributions")]
        public long LegacyYtdContributions { get; set; }

        [JsonProperty("LegacyYtdDistributions")]
        public long LegacyYtdDistributions { get; set; }
        
        [JsonConstructor]
        public AccountSettings(long accountId, long investmentObjectiveId, string investmentReviewFrequencyType, long investmentReviewFrequencyMonthOffset, string administrativeReviewFrequencyType, long administrativeReviewFrequencyMonthOffset, bool isPurchaseRestricted, bool isSalesRestricted, DateTimeOffset dateOfRestrictionExpiration, bool isMutualFundPurchaseRestricted, bool isMutualFundSalesRestricted, DateTimeOffset dateOfMutualFundRestrictionExpiration, bool isInternalReportRecipient, bool showExtraordinaryFeeSummary, string reinvestOptionType, string specificPowers, string distributionOfPrincipal, bool isPrincipalOnly, long capacityCategoryId, long investmentPowerTypeId, string proxyInvestmentPowerType, long longTermLossCarryForwardAmount, long shortTermLossCarryForwardAmount, DateTimeOffset dateCarryForward, string taxationType, DateTimeOffset dateTaxYearEnd, long capitalGainRatePercent, string taxInterfaceType, string tax1099LevelType, bool isOverdraftAllowed, bool isNetCashOverdraft, long sweepSetupId, string cashAutoTransferType, long principalReserveAmount, long incomeReserveAmount, long sweepPrincipalReserveAmount, long sweepIncomeReserveAmount, string taxLotHarvestingType, string amortizationType, string comptrollerType, string cashDescription, long performanceIndexSettingId, List<PerformanceExclusion> performanceExclusions, long legacyPriorYearEndMarketValue, long legacyYtdContributions, long legacyYtdDistributions)
        {
            AccountId = accountId;
            InvestmentObjectiveId = investmentObjectiveId;
            InvestmentReviewFrequencyType = investmentReviewFrequencyType;
            InvestmentReviewFrequencyMonthOffset = investmentReviewFrequencyMonthOffset;
            AdministrativeReviewFrequencyType = administrativeReviewFrequencyType;
            AdministrativeReviewFrequencyMonthOffset = administrativeReviewFrequencyMonthOffset;
            IsPurchaseRestricted = isPurchaseRestricted;
            IsSalesRestricted = isSalesRestricted;
            DateOfRestrictionExpiration = dateOfRestrictionExpiration;
            IsMutualFundPurchaseRestricted = isMutualFundPurchaseRestricted;
            IsMutualFundSalesRestricted = isMutualFundSalesRestricted;
            DateOfMutualFundRestrictionExpiration = dateOfMutualFundRestrictionExpiration;
            IsInternalReportRecipient = isInternalReportRecipient;
            ShowExtraordinaryFeeSummary = showExtraordinaryFeeSummary;
            ReinvestOptionType = reinvestOptionType;
            SpecificPowers = specificPowers;
            DistributionOfPrincipal = distributionOfPrincipal;
            IsPrincipalOnly = isPrincipalOnly;
            CapacityCategoryId = capacityCategoryId;
            InvestmentPowerTypeId = investmentPowerTypeId;
            ProxyInvestmentPowerType = proxyInvestmentPowerType;
            LongTermLossCarryForwardAmount = longTermLossCarryForwardAmount;
            ShortTermLossCarryForwardAmount = shortTermLossCarryForwardAmount;
            DateCarryForward = dateCarryForward;
            TaxationType = taxationType;
            DateTaxYearEnd = dateTaxYearEnd;
            CapitalGainRatePercent = capitalGainRatePercent;
            TaxInterfaceType = taxInterfaceType;
            Tax1099LevelType = tax1099LevelType;
            IsOverdraftAllowed = isOverdraftAllowed;
            IsNetCashOverdraft = isNetCashOverdraft;
            SweepSetupId = sweepSetupId;
            CashAutoTransferType = cashAutoTransferType;
            PrincipalReserveAmount = principalReserveAmount;
            IncomeReserveAmount = incomeReserveAmount;
            SweepPrincipalReserveAmount = sweepPrincipalReserveAmount;
            SweepIncomeReserveAmount = sweepIncomeReserveAmount;
            TaxLotHarvestingType = taxLotHarvestingType;
            AmortizationType = amortizationType;
            ComptrollerType = comptrollerType;
            CashDescription = cashDescription;
            PerformanceIndexSettingId = performanceIndexSettingId;
            PerformanceExclusions = performanceExclusions;
            LegacyPriorYearEndMarketValue = legacyPriorYearEndMarketValue;
            LegacyYtdContributions = legacyYtdContributions;
            LegacyYtdDistributions = legacyYtdDistributions;
        }
    }
}