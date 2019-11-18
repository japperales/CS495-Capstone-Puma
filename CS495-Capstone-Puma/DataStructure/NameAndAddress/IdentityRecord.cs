﻿using System;
 using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.DataStructure.NameAndAddress
{
    public class IdentityRecord
    {
        [JsonProperty("IdentityRecordId")]
        public int IdentityRecordId { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("PayeeName")]
        public string PayeeName { get; set; }

        [JsonProperty("TaxIdStatusType")]
        public string TaxIdStatusType { get; set; }

        [JsonProperty("TaxId")]
        public string TaxId { get; set; }

        [JsonProperty("TaxIdType")]
        public string TaxIdType { get; set; }

        [JsonProperty("DomainModelClass")]
        public string DomainModelClass { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("SalutationType")]
        public string SalutationType { get; set; }

        [JsonProperty("GenderType")]
        public string GenderType { get; set; }

        [JsonProperty("FirstNameLegalName")]
        public string FirstNameLegalName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("ContactName")]
        public string ContactName { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTimeOffset? DateOfBirth { get; set; }

        [JsonProperty("DateOfDeath")]
        public DateTimeOffset? DateOfDeath { get; set; }

        [JsonProperty("PhoneNumbers")]
        public List<ContactMethod> PhoneNumbers { get; set; }

        [JsonProperty("Emails")]
        public List<ContactMethod> Emails { get; set; }

        [JsonProperty("Addresses")]
        public List<Address> Addresses { get; set; }

        [JsonProperty("IdentityClassificationTypes")]
        public List<string> IdentityClassificationTypes { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("InstitutionIdentityRecordId")]
        public long? InstitutionIdentityRecordId { get; set; }

        public IdentityRecord()
        {
            IdentityRecordId = 0;
            DisplayName = null;
            Code = null;
            PayeeName = null;
            TaxIdStatusType = null;
            TaxId = null;
            TaxIdType = null;
            DomainModelClass = null;
            Comments = null;
            SalutationType = null;
            GenderType = null;
            FirstNameLegalName = null;
            MiddleName = null;
            LastName = null;
            Title = null;
            ContactName = null;
            DateOfBirth = null;
            DateOfDeath = null;
            PhoneNumbers = null;
            Emails = null;
            Addresses = null;
            IdentityClassificationTypes = null;
            IsActive = true;
            InstitutionIdentityRecordId = null;
        }

        [JsonConstructor]
        public IdentityRecord(int identityRecordId, string displayName)
        {
            IdentityRecordId = identityRecordId;
            DisplayName = displayName;
        }
    }
}