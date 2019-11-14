using System;
using System.Collections.Generic;
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
        public long DivisionIdentityRecordId { get; set; }

        [JsonProperty("AccountCategoryId")]
        public long AccountCategoryId { get; set; }

        [JsonProperty("DateOpened")]
        public DateTimeOffset DateOpened { get; set; }

        [JsonProperty("DateEstablished")]
        public DateTimeOffset DateEstablished { get; set; }

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
        public long OfficerId { get; set; }

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
        
        [JsonConstructor]
        public Account(long accountId, bool failOnRelationshipLookup, string number, string code, string legalName, string displayName, long divisionIdentityRecordId, long accountCategoryId, DateTimeOffset dateOpened, DateTimeOffset dateEstablished, string country, string stateProvince, string taxIdStatusType, string taxId, string taxIdType, string comments, long officerId, string beneficialOwnerTaxId, AccountRelationship accountRelationship, AccountSettings accountSettings, FeeSetting feeSetting, List<InvestmentModelSetting> investmentModelSettings)
        {
            AccountId = accountId;
            FailOnRelationshipLookup = failOnRelationshipLookup;
            Number = number;
            Code = code;
            LegalName = legalName;
            DisplayName = displayName;
            DivisionIdentityRecordId = divisionIdentityRecordId;
            AccountCategoryId = accountCategoryId;
            DateOpened = dateOpened;
            DateEstablished = dateEstablished;
            Country = country;
            StateProvince = stateProvince;
            TaxIdStatusType = taxIdStatusType;
            TaxId = taxId;
            TaxIdType = taxIdType;
            Comments = comments;
            OfficerId = officerId;
            BeneficialOwnerTaxId = beneficialOwnerTaxId;
            AccountRelationship = accountRelationship;
            AccountSettings = accountSettings;
            FeeSetting = feeSetting;
            InvestmentModelSettings = investmentModelSettings;
        }
    }
}