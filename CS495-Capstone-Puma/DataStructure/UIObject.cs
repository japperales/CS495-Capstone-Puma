using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using Newtonsoft.Json;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;

namespace CS495_Capstone_Puma.DataStructure
{
    public class UIObject
    {
        [JsonProperty("IdentityRecord")]
        public IdentityRecord IdentityRecordObj { get; set; }
        
        [JsonProperty("BondList")]
        public List<Bond> Bonds { get; set; }
        
        [JsonProperty("MiscList")]
        public List<CashEquivalent> CashEquivalents { get; set; }
        
        [JsonProperty("LoanList")]
        public List<Loan> Loans { get; set; }
        
        [JsonProperty("MutualFundList")]
        public List<MutualFund> MutualFunds { get; set; }
        
        [JsonProperty("StockList")]
        public List<Stock> Stocks { get; set; }
        
        [JsonProperty("PropertyList")]
        public List<Property> Properties { get; set; }
        
        [JsonProperty("Assets")]
        public List<Asset.Asset> Assets { get; set; }
        
        public UIObject()
        {
            IdentityRecordObj = null;
            Bonds = null;
            CashEquivalents = null;
            Loans = null;
            MutualFunds = null;
            Stocks = null;
            Properties = null;
        }

        [JsonConstructor]
        public UIObject(IdentityRecord identityRecord, List<Bond> bonds, List<CashEquivalent> cashEquivalents, List<Loan> loans, List<MutualFund> mutualFunds, List<Stock> stocks, List<Property> properties)
        {
            IdentityRecordObj = identityRecord;
            Bonds = bonds;
            CashEquivalents = cashEquivalents;
            Loans = loans;
            MutualFunds = mutualFunds;
            Stocks = stocks;
            Properties = properties;
        }

        public UIObject(IdentityRecord identityRecord, List<Asset.Asset> assets)
        {
            IdentityRecordObj = identityRecord;
            Assets = assets;
        }
    }
}