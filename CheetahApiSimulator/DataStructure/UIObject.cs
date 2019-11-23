using System.Collections.Generic;
using CheetahApiSimulator.DataStructure.Asset.AssetCategory;
using Newtonsoft.Json;
using CheetahApiSimulator.DataStructure.NameAndAddress;

namespace CheetahApiSimulator.DataStructure
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
            Bonds = new List<Bond>();
            CashEquivalents = new List<CashEquivalent>();
            Loans = new List<Loan>();
            MutualFunds = new List<MutualFund>();
            Stocks = new List<Stock>();
            Properties = new List<Property>();
        }

        [JsonConstructor]
        public UIObject(IdentityRecord identityRecord, List<CashEquivalent> cashEquivalents = null, List<Loan> loans = null,
            List<MutualFund> mutualFunds = null, List<Stock> stocks = null, List<Property> properties = null,
            List<Bond> bonds = null)
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