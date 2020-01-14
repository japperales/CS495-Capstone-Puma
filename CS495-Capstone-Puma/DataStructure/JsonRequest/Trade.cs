using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class Trade
    {
        [JsonProperty("TradeId")]
        public long TradeId { get; set; }

        [JsonProperty("TradeBlockId")]
        public long TradeBlockId { get; set; }

        [JsonProperty("TradeBlockName")]
        public string TradeBlockName { get; set; }

        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("TradeGroupKey")]
        public string TradeGroupKey { get; set; }

        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("AssetId")]
        public long AssetId { get; set; }

        [JsonProperty("AssetCode")]
        public string AssetCode { get; set; }

        [JsonProperty("OverrideTaxLotHarvestingType")]
        public string OverrideTaxLotHarvestingType { get; set; }

        [JsonProperty("OverrideTaxLotHarvestingTypeName")]
        public string OverrideTaxLotHarvestingTypeName { get; set; }

        [JsonProperty("UseSpecifiedLot")]
        public string UseSpecifiedLot { get; set; }

        [JsonProperty("TradeType")]
        public string TradeType { get; set; }

        [JsonProperty("TradeTypeName")]
        public string TradeTypeName { get; set; }

        [JsonProperty("TradeDurationType")]
        public string TradeDurationType { get; set; }

        [JsonProperty("TradeDurationTypeName")]
        public string TradeDurationTypeName { get; set; }

        [JsonProperty("TradePriceType")]
        public string TradePriceType { get; set; }

        [JsonProperty("TradePriceTypeName")]
        public string TradePriceTypeName { get; set; }

        [JsonProperty("TradeBasisOptionType")]
        public string TradeBasisOptionType { get; set; }

        [JsonProperty("TradeBasisOptionTypeName")]
        public string TradeBasisOptionTypeName { get; set; }

        [JsonProperty("TradeStatusType")]
        public string TradeStatusType { get; set; }

        [JsonProperty("TradeStatusTypeName")]
        public string TradeStatusTypeName { get; set; }

        [JsonProperty("TradeBlockHold")]
        public bool TradeBlockHold { get; set; }

        [JsonProperty("TradedPriceAmount")]
        public long TradedPriceAmount { get; set; }

        [JsonProperty("DateTraded")]
        public DateTimeOffset DateTraded { get; set; }

        [JsonProperty("DateSettled")]
        public DateTimeOffset DateSettled { get; set; }

        [JsonProperty("TaxYear")]
        public long TaxYear { get; set; }

        [JsonProperty("ExecuteInSingleBlock")]
        public bool ExecuteInSingleBlock { get; set; }

        [JsonProperty("StopPriceAmount")]
        public long StopPriceAmount { get; set; }

        [JsonProperty("LimitPriceAmount")]
        public long LimitPriceAmount { get; set; }

        [JsonProperty("UnitShares")]
        public long UnitShares { get; set; }

        [JsonProperty("NetAmount")]
        public long NetAmount { get; set; }

        [JsonProperty("UseIncomeCash")]
        public bool UseIncomeCash { get; set; }

        [JsonProperty("AccruedInterestAmount")]
        public long AccruedInterestAmount { get; set; }

        [JsonProperty("BrokerIdentityRecordId")]
        public long BrokerIdentityRecordId { get; set; }

        [JsonProperty("CommissionFee")]
        public long CommissionFee { get; set; }

        [JsonProperty("SecFee")]
        public long SecFee { get; set; }

        [JsonProperty("OtherFee")]
        public long OtherFee { get; set; }

        [JsonProperty("RegistrationTypeId")]
        public long RegistrationTypeId { get; set; }

        [JsonProperty("RegistrationTypeName")]
        public string RegistrationTypeName { get; set; }

        [JsonProperty("LocationTypeId")]
        public long LocationTypeId { get; set; }

        [JsonProperty("LocationTypeName")]
        public string LocationTypeName { get; set; }

        [JsonProperty("DivisionIdentityRecordId")]
        public long DivisionIdentityRecordId { get; set; }

        [JsonProperty("TransactionNarrativeId")]
        public long TransactionNarrativeId { get; set; }

        [JsonProperty("Narrative")]
        public string Narrative { get; set; }

        [JsonProperty("ProcessingExceptionType")]
        public string ProcessingExceptionType { get; set; }

        [JsonProperty("ProcessingExceptionTypeName")]
        public string ProcessingExceptionTypeName { get; set; }

        [JsonProperty("TradeProposalId")]
        public long TradeProposalId { get; set; }

        [JsonProperty("TradeProposalName")]
        public string TradeProposalName { get; set; }

        [JsonProperty("TradeProposalSourceType")]
        public string TradeProposalSourceType { get; set; }

        [JsonProperty("TradeProposalSourceTypeName")]
        public string TradeProposalSourceTypeName { get; set; }

        [JsonProperty("TradeProposalStatusType")]
        public string TradeProposalStatusType { get; set; }

        [JsonProperty("TradeProposalStatusTypeName")]
        public string TradeProposalStatusTypeName { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonConstructor]
        public Trade(long tradeId, long tradeBlockId, string tradeBlockName, long accountId, string tradeGroupKey, string accountNumber, long assetId, string assetCode, string overrideTaxLotHarvestingType, string overrideTaxLotHarvestingTypeName, string useSpecifiedLot, string tradeType, string tradeTypeName, string tradeDurationType, string tradeDurationTypeName, string tradePriceType, string tradePriceTypeName, string tradeBasisOptionType, string tradeBasisOptionTypeName, string tradeStatusType, string tradeStatusTypeName, bool tradeBlockHold, long tradedPriceAmount, DateTimeOffset dateTraded, DateTimeOffset dateSettled, long taxYear, bool executeInSingleBlock, long stopPriceAmount, long limitPriceAmount, long unitShares, long netAmount, bool useIncomeCash, long accruedInterestAmount, long brokerIdentityRecordId, long commissionFee, long secFee, long otherFee, long registrationTypeId, string registrationTypeName, long locationTypeId, string locationTypeName, long divisionIdentityRecordId, long transactionNarrativeId, string narrative, string processingExceptionType, string processingExceptionTypeName, long tradeProposalId, string tradeProposalName, string tradeProposalSourceType, string tradeProposalSourceTypeName, string tradeProposalStatusType, string tradeProposalStatusTypeName, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
        {
            TradeId = tradeId;
            TradeBlockId = tradeBlockId;
            TradeBlockName = tradeBlockName;
            AccountId = accountId;
            TradeGroupKey = tradeGroupKey;
            AccountNumber = accountNumber;
            AssetId = assetId;
            AssetCode = assetCode;
            OverrideTaxLotHarvestingType = overrideTaxLotHarvestingType;
            OverrideTaxLotHarvestingTypeName = overrideTaxLotHarvestingTypeName;
            UseSpecifiedLot = useSpecifiedLot;
            TradeType = tradeType;
            TradeTypeName = tradeTypeName;
            TradeDurationType = tradeDurationType;
            TradeDurationTypeName = tradeDurationTypeName;
            TradePriceType = tradePriceType;
            TradePriceTypeName = tradePriceTypeName;
            TradeBasisOptionType = tradeBasisOptionType;
            TradeBasisOptionTypeName = tradeBasisOptionTypeName;
            TradeStatusType = tradeStatusType;
            TradeStatusTypeName = tradeStatusTypeName;
            TradeBlockHold = tradeBlockHold;
            TradedPriceAmount = tradedPriceAmount;
            DateTraded = dateTraded;
            DateSettled = dateSettled;
            TaxYear = taxYear;
            ExecuteInSingleBlock = executeInSingleBlock;
            StopPriceAmount = stopPriceAmount;
            LimitPriceAmount = limitPriceAmount;
            UnitShares = unitShares;
            NetAmount = netAmount;
            UseIncomeCash = useIncomeCash;
            AccruedInterestAmount = accruedInterestAmount;
            BrokerIdentityRecordId = brokerIdentityRecordId;
            CommissionFee = commissionFee;
            SecFee = secFee;
            OtherFee = otherFee;
            RegistrationTypeId = registrationTypeId;
            RegistrationTypeName = registrationTypeName;
            LocationTypeId = locationTypeId;
            LocationTypeName = locationTypeName;
            DivisionIdentityRecordId = divisionIdentityRecordId;
            TransactionNarrativeId = transactionNarrativeId;
            Narrative = narrative;
            ProcessingExceptionType = processingExceptionType;
            ProcessingExceptionTypeName = processingExceptionTypeName;
            TradeProposalId = tradeProposalId;
            TradeProposalName = tradeProposalName;
            TradeProposalSourceType = tradeProposalSourceType;
            TradeProposalSourceTypeName = tradeProposalSourceTypeName;
            TradeProposalStatusType = tradeProposalStatusType;
            TradeProposalStatusTypeName = tradeProposalStatusTypeName;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}