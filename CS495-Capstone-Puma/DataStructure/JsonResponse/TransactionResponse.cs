using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.JsonResponse
{
    public class TransactionResponse
    {
        [JsonProperty("TransactionId")]
        public int transactionId { get; set; }

        [JsonProperty("TransactionCategoryId")]
        public int transactionCategoryId { get; set; }

        [JsonProperty("TransactionBatchId")]
        public int transactionBatchId { get; set; }

        [JsonProperty("TransactionStatusType")]
        public string transactionStatusType { get; set; }

        [JsonProperty("TransactionStatusTypeName")]
        public string transactionStatusTypeName { get; set; }

        [JsonProperty("AccountId")]
        public int accountId { get; set; }

        [JsonProperty("AssetId")]
        public int assetId { get; set; }

        [JsonProperty("DateTraded")]
        public DateTimeOffset dateTraded { get; set; }

        [JsonProperty("DateSettled")]
        public DateTimeOffset dateSettled { get; set; }

        [JsonProperty("TaxYear")]
        public int taxYear { get; set; }

        [JsonProperty("Units")]
        public long units { get; set; }

        [JsonProperty("PrincipalCashAmount")]
        public long principalCashAmount { get; set; }

        [JsonProperty("IncomeCashAmount")]
        public long incomeCashAmount { get; set; }

        [JsonProperty("PrincipalInvestAmount")]
        public long principalInvestAmount { get; set; }

        [JsonProperty("IncomeInvestAmount")]
        public long incomeInvestAmount { get; set; }

        [JsonProperty("StateInvestAmount")]
        public long stateInvestAmount { get; set; }

        [JsonProperty("PrincipalInventoryAmount")]
        public long principalInventoryAmount { get; set; }

        [JsonProperty("IncomeInventoryAmount")]
        public long incomeInventoryAmount { get; set; }

        [JsonProperty("BalanceAdjustmentOverride")]
        public bool balanceAdjustmentOverride { get; set; }

        [JsonProperty("RegistrationTypeId")]
        public long registrationTypeId { get; set; }

        [JsonProperty("LocationTypeId")]
        public long locationTypeId { get; set; }

        [JsonProperty("StatementReportOptionType")]
        public long statementReportOptionType { get; set; }

        [JsonProperty("StatementReportOptionTypeName")]
        public string statementReportOptionTypeName { get; set; }

        [JsonProperty("CommissionFee")]
        public long commissionFee { get; set; }

        [JsonProperty("SecFee")]
        public long secFee { get; set; }

        [JsonProperty("OtherFee")]
        public long otherFee { get; set; }

        [JsonProperty("TradingFeeOverride")]
        public bool tradingFeeOverride { get; set; }
        
        public TransactionResponse()
        {
            transactionId = 0;
            transactionCategoryId = 0;
            transactionBatchId = 0;
            transactionStatusType = "";
            transactionStatusTypeName = "";
            accountId = 0;
            assetId = 0;
            dateTraded = DateTime.Now;
            dateSettled = DateTime.Now;
            taxYear = 2020;
            units = 0;
            principalCashAmount = 0;
            incomeCashAmount = 0;
            principalInvestAmount = 0;
            incomeInvestAmount = 0;
            stateInvestAmount = 0;
            principalInventoryAmount = 0;
            incomeInventoryAmount = 0;
            balanceAdjustmentOverride = false;
            registrationTypeId = 0;
            locationTypeId = 0;
            statementReportOptionType = 0;
            statementReportOptionTypeName = "";
            commissionFee = 0;
            secFee = 0;
            otherFee = 0;
            tradingFeeOverride = false;
        }
        
        [JsonConstructor]
         public TransactionResponse(int transactionId, int transactionCategoryId, int transactionBatchId, string transactionStatusType, string transactionStatusTypeName, int accountId, int assetId, DateTimeOffset dateTraded, DateTimeOffset dateSettled, int taxYear, long units, long principalCashAmount, long incomeCashAmount, long principalInvestAmount, long incomeInvestAmount, long stateInvestAmount, long principalInventoryAmount, long incomeInventoryAmount, bool balanceAdjustmentOverride, long registrationTypeId, long locationTypeId, long statementReportOptionType, string statementReportOptionTypeName, long commissionFee, long secFee, long otherFee, bool tradingFeeOverride)
        {
            this.transactionId = transactionId;
            this.transactionCategoryId = transactionCategoryId;
            this.transactionBatchId = transactionBatchId;
            this.transactionStatusType = transactionStatusType;
            this.transactionStatusTypeName = transactionStatusTypeName;
            this.accountId = accountId;
            this.assetId = assetId;
            this.dateTraded = dateTraded;
            this.dateSettled = dateSettled;
            this.taxYear = taxYear;
            this.units = units;
            this.principalCashAmount = principalCashAmount;
            this.incomeCashAmount = incomeCashAmount;
            this.principalInvestAmount = principalInvestAmount;
            this.incomeInvestAmount = incomeInvestAmount;
            this.stateInvestAmount = stateInvestAmount;
            this.principalInventoryAmount = principalInventoryAmount;
            this.incomeInventoryAmount = incomeInventoryAmount;
            this.balanceAdjustmentOverride = balanceAdjustmentOverride;
            this.registrationTypeId = registrationTypeId;
            this.locationTypeId = locationTypeId;
            this.statementReportOptionType = statementReportOptionType;
            this.statementReportOptionTypeName = statementReportOptionTypeName;
            this.commissionFee = commissionFee;
            this.secFee = secFee;
            this.otherFee = otherFee;
            this.tradingFeeOverride = tradingFeeOverride;
        }
    }
}