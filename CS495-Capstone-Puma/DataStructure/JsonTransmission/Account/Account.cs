using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.JsonTransmission.NameAndAddress;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class Account
    {
        [JsonProperty("FailOnRelationshipLookup")]
        public bool FailOnRelationshipLookup { get; set; }

        [JsonProperty("LegalName")]
        public string LegalName { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("DivisionIdentityRecordId")]
        public long? DivisionIdentityRecordId { get; set; }

        [JsonProperty("AccountCategoryId")]
        public long? AccountCategoryId { get; set; }

        [JsonProperty("DateOpened")]
        public DateTimeOffset? DateOpened { get; set; }

        [JsonProperty("DateEstablished")]
        public DateTimeOffset? DateEstablished { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("StateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("TaxIdStatusType")]
        public string TaxIdStatusType { get; set; }

        [JsonProperty("OfficerId")]
        public long? OfficerId { get; set; }

        [JsonProperty("AccountRelationship")]
        public AccountRelationship AccountRelationship { get; set; }

        [JsonProperty("AccountSettings")]
        public AccountSettings AccountSettings { get; set; }

        [JsonProperty("InvestmentModelSettings")]
        public List<InvestmentModelSetting> InvestmentModelSettings { get; set; }
        
        public Account()
        {
            FailOnRelationshipLookup = false;
            LegalName = null;
            DisplayName = null;
            DivisionIdentityRecordId = 2;
            AccountCategoryId = null;
            DateEstablished = DateTimeOffset.Now;
            DateOpened = DateTimeOffset.Now;
            Country = null;
            StateProvince = null;
            TaxIdStatusType = null;
            OfficerId = 1636;
            AccountRelationship = null;
            AccountSettings = null;
            InvestmentModelSettings = null;
        }

        [JsonConstructor]
        public Account(IdentityRecord identityRecord, int accountCategoryId, string country, string stateProvince,
            int investmentObjectiveId, int investmentModelId)
        {
            LegalName = identityRecord.FirstNameLegalName + " " + identityRecord.LastName;
            DisplayName = LegalName;
            AccountCategoryId = accountCategoryId;
            Country = country;
            StateProvince = stateProvince;
            AccountRelationship = new AccountRelationship(identityRecord.FirstNameLegalName, identityRecord.LastName, DisplayName);
            AccountSettings = new AccountSettings(investmentObjectiveId);
            InvestmentModelSettings = new List<InvestmentModelSetting>
            {
                new InvestmentModelSetting(investmentModelId, 7, 1)
            };
        }
    }
}