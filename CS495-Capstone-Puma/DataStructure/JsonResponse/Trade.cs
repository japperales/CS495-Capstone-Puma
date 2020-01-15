using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
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

        [JsonProperty("UnitShares")]
        public long UnitShares { get; set; }

        [JsonProperty("NetAmount")]
        public long NetAmount { get; set; }

        [JsonProperty("UseIncomeCash")]
        public bool UseIncomeCash { get; set; }

        [JsonProperty("BrokerIdentityRecordId")]
        public long BrokerIdentityRecordId { get; set; }

        [JsonProperty("CommissionFee")]
        public long CommissionFee { get; set; }

        [JsonProperty("SecFee")]
        public long SecFee { get; set; }

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

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        public Trade()
        {
            TradeId = 0;
            TradeBlockId = 0;
            TradeBlockName = "";
            AccountId = 0;
            TradeGroupKey = "";
            AccountNumber = "";
            AssetId = 0;
            AssetCode = "";
            OverrideTaxLotHarvestingType = "";
            OverrideTaxLotHarvestingTypeName = "";
            UseSpecifiedLot = "";
            TradeType = "";
            TradeTypeName = "";
            TradeDurationType = "";
            TradeDurationTypeName = "";
            TradePriceType = "";
            TradePriceTypeName = "";
            TradeBasisOptionType = "";
            TradeBasisOptionTypeName = "";
            TradeStatusType = "";
            TradeStatusTypeName = "";
            TradeBlockHold = false;
            TradedPriceAmount = 0;
            DateTraded = DateTimeOffset.Now;
            DateSettled = DateTimeOffset.Now;
            TaxYear = 2020;
            ExecuteInSingleBlock = false;
            UnitShares = 200;
            NetAmount = 20199;
            UseIncomeCash = false;
            BrokerIdentityRecordId = 19;
            CommissionFee = 0;
            SecFee = 2;
            RegistrationTypeId = 1;
            RegistrationTypeName = "";
            LocationTypeId = 1;
            LocationTypeName = "";
            DivisionIdentityRecordId = 24;
            CreatedDate = DateTimeOffset.Now;
            ModifiedDate = DateTimeOffset.Now;
            ModifiedBy = "";
        }
        
        [JsonConstructor]
        public Trade(long tradeId, long tradeBlockId, string tradeBlockName, long accountId, string tradeGroupKey, string accountNumber, long assetId, string assetCode, string overrideTaxLotHarvestingType, string overrideTaxLotHarvestingTypeName, string useSpecifiedLot, string tradeType, string tradeTypeName, string tradeDurationType, string tradeDurationTypeName, string tradePriceType, string tradePriceTypeName, string tradeBasisOptionType, string tradeBasisOptionTypeName, string tradeStatusType, string tradeStatusTypeName, bool tradeBlockHold, long tradedPriceAmount, DateTimeOffset dateTraded, DateTimeOffset dateSettled, long taxYear, bool executeInSingleBlock, long unitShares, long netAmount, bool useIncomeCash, long brokerIdentityRecordId, long commissionFee, long secFee, long registrationTypeId, string registrationTypeName, long locationTypeId, string locationTypeName, long divisionIdentityRecordId, DateTimeOffset createdDate, DateTimeOffset modifiedDate, string modifiedBy)
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
            UnitShares = unitShares;
            NetAmount = netAmount;
            UseIncomeCash = useIncomeCash;
            BrokerIdentityRecordId = brokerIdentityRecordId;
            CommissionFee = commissionFee;
            SecFee = secFee;
            RegistrationTypeId = registrationTypeId;
            RegistrationTypeName = registrationTypeName;
            LocationTypeId = locationTypeId;
            LocationTypeName = locationTypeName;
            DivisionIdentityRecordId = divisionIdentityRecordId;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }
}