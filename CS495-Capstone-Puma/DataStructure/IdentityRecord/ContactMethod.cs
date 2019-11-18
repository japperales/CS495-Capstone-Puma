﻿using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.DataStructure.IdentityRecord
{
    public class ContactMethod
    {
        [JsonProperty("EmailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }

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

        [JsonProperty("Number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
        
        [JsonConstructor]
        public ContactMethod(string emailAddress, long identityRecordId, long contactMechanismId, string contactMechanismType, string contactMechanismUseType, bool isPrimary, long monthEffectiveFrom, long monthEffectiveTo, long dayEffectiveFrom, long dayEffectiveTo, bool isActive, string note, List<string> contactMechanismPurposeTypes, long institutionIdentityRecordId, string number)
        {
            EmailAddress = emailAddress;
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
            Number = number;
        }
    }
}