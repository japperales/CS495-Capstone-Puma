using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class Account
    {
        [JsonProperty("AccountId")]
        public long AccountId { get; set; }

        [JsonProperty("FailOnRelationshipLookup")]
        public bool FailOnRelationshipLookup { get; set; }

        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

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

        [JsonProperty("TaxId")]
        public string TaxId { get; set; }

        [JsonProperty("TaxIdType")]
        public string TaxIdType { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("OfficerId")]
        public long? OfficerId { get; set; }

        [JsonProperty("BeneficialOwnerTaxId")]
        public string BeneficialOwnerTaxId { get; set; }

        [JsonProperty("AccountRelationship")]
        public AccountRelationship AccountRelationship { get; set; }

        [JsonProperty("AccountSettings")]
        public AccountSettings AccountSettings { get; set; }

        [JsonProperty("FeeSetting")]
        public FeeSetting FeeSetting { get; set; }

        [JsonProperty("InvestmentModelSettings")]
        public List<InvestmentModelSetting> InvestmentModelSettings { get; set; }
        
        public Account()
        {
            AccountId = 0;
            FailOnRelationshipLookup = false;
            Number = null;
            Code = null;
            LegalName = null;
            DisplayName = null;
            DivisionIdentityRecordId = null;
            AccountCategoryId = null;
            DateOpened = null;
            DateEstablished = null;
            Country = null;
            StateProvince = null;
            TaxIdStatusType = null;
            TaxId = null;
            TaxIdType = null;
            Comments = null;
            OfficerId = null;
            BeneficialOwnerTaxId = null;
            AccountRelationship = null;
            AccountSettings = null;
            FeeSetting = null;
            InvestmentModelSettings = null;
        }

        public Account(int id, IdentityRecord identityRecord)
        {
            AccountId = id;
            LegalName = identityRecord.FirstNameLegalName + " " + identityRecord.LastName;
        }
    }
}