﻿using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.DataStructure.JsonTransmission.NameAndAddress
{
    public class Address
    {
        [JsonProperty("Attention")]
        public string Attention { get; set; }

        [JsonProperty("Line1")]
        public string Line1 { get; set; }

        [JsonProperty("Line2")]
        public string Line2 { get; set; }

        [JsonProperty("Line3")]
        public string Line3 { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("StateProvince")]
        public string StateProvince { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("SpecialInstructions")]
        public string SpecialInstructions { get; set; }

        [JsonProperty("IdentityRecordId")]
        public long IdentityRecordId { get; set; }

        [JsonProperty("ContactMechanismId")]
        public long ContactMechanismId { get; set; }

        [JsonProperty("ContactMechanismType")]
        public string ContactMechanismType { get; set; }

        [JsonProperty("ContactMechanismUseType")]
        public string ContactMechanismUseType { get; set; }

        [JsonProperty("IsPrimary")]
        public bool IsPrimary { get; set; }

        [JsonProperty("MonthEffectiveFrom")]
        public long MonthEffectiveFrom { get; set; }

        [JsonProperty("MonthEffectiveTo")]
        public long MonthEffectiveTo { get; set; }

        [JsonProperty("DayEffectiveFrom")]
        public long DayEffectiveFrom { get; set; }

        [JsonProperty("DayEffectiveTo")]
        public long DayEffectiveTo { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("Note")]
        public string Note { get; set; }

        [JsonProperty("ContactMechanismPurposeTypes")]
        public List<string> ContactMechanismPurposeTypes { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public Address(string attention, string line1, string line2, string line3, string city, string postalCode, string stateProvince, string country, string specialInstructions, long identityRecordId, long contactMechanismId, string contactMechanismType, string contactMechanismUseType, bool isPrimary, long monthEffectiveFrom, long monthEffectiveTo, long dayEffectiveFrom, long dayEffectiveTo, bool isActive, string note, List<string> contactMechanismPurposeTypes, long institutionIdentityRecordId)
        {
            Attention = attention;
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            City = city;
            PostalCode = postalCode;
            StateProvince = stateProvince;
            Country = country;
            SpecialInstructions = specialInstructions;
            IdentityRecordId = identityRecordId;
            ContactMechanismId = contactMechanismId;
            ContactMechanismType = contactMechanismType;
            ContactMechanismUseType = contactMechanismUseType;
            IsPrimary = isPrimary;
            MonthEffectiveFrom = monthEffectiveFrom;
            MonthEffectiveTo = monthEffectiveTo;
            DayEffectiveFrom = dayEffectiveFrom;
            DayEffectiveTo = dayEffectiveTo;
            IsActive = isActive;
            Note = note;
            ContactMechanismPurposeTypes = contactMechanismPurposeTypes;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}