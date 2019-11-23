﻿using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CheetahApiSimulator.DataStructure.NameAndAddress
{
    public class ContactMethod
    {
        [JsonProperty("EmailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }

        [JsonProperty("IdentityRecordId")]
        public long? IdentityRecordId { get; set; }

        [JsonProperty("ContactMechanismId")]
        public long? ContactMechanismId { get; set; }

        [JsonProperty("ContactMechanismType")]
        public string ContactMechanismType { get; set; }

        [JsonProperty("ContactMechanismUseType")]
        public string ContactMechanismUseType { get; set; }

        [JsonProperty("IsPrimary")]
        public bool? IsPrimary { get; set; }

        [JsonProperty("MonthEffectiveFrom")]
        public long? MonthEffectiveFrom { get; set; }

        [JsonProperty("MonthEffectiveTo")]
        public long? MonthEffectiveTo { get; set; }

        [JsonProperty("DayEffectiveFrom")]
        public long? DayEffectiveFrom { get; set; }

        [JsonProperty("DayEffectiveTo")]
        public long? DayEffectiveTo { get; set; }

        [JsonProperty("IsActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("Note")]
        public string Note { get; set; }

        [JsonProperty("ContactMechanismPurposeTypes")]
        public List<string> ContactMechanismPurposeTypes { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long? InstitutionIdentityRecordId { get; set; }

        [JsonProperty("Number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }

        public ContactMethod()
        {
            EmailAddress = null;
            IdentityRecordId = null;
            ContactMechanismId = null;
            ContactMechanismType = null;
            ContactMechanismUseType = null;
            IsPrimary = null;
            MonthEffectiveFrom = null;
            MonthEffectiveTo = null;
            DayEffectiveFrom = null;
            DayEffectiveTo = null;
            IsActive = null;
            Note = null;
            ContactMechanismPurposeTypes = null;
            InstitutionIdentityRecordId = null;
            Number = null;
        }

        public ContactMethod(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}