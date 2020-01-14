﻿using System;
 using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.DataStructure.JsonTransmission.NameAndAddress
{
    public class IdentityRecord
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("TaxIdStatusType")]
        public string TaxIdStatusType { get; set; }

        [JsonProperty("DomainModelClass")]
        public string DomainModelClass { get; set; }

        [JsonProperty("GenderType")]
        public string GenderType { get; set; }

        [JsonProperty("FirstNameLegalName")]
        public string FirstNameLegalName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("ContactName")]
        public string ContactName { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTimeOffset? DateOfBirth { get; set; }

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
            DisplayName = "John Doe";
            TaxIdStatusType = "NotUsed";
            DomainModelClass = "Individual";
            GenderType = "Male";
            FirstNameLegalName = "John";
            LastName = "Doe";
            Title = "Mr.";
            ContactName = "John Doe";
            DateOfBirth = DateTimeOffset.Now;
            Addresses = null;
            IdentityClassificationTypes = new List<string>{"User"};
            IsActive = true;
            InstitutionIdentityRecordId = 1;
        }

        [JsonConstructor]
        public IdentityRecord(string domainModelClass, string firstNameLegalName, string lastName, string title, List<Address> addresses)
        {
            DisplayName = firstNameLegalName + lastName;
            DomainModelClass = domainModelClass;
            FirstNameLegalName = firstNameLegalName;
            LastName = lastName;
            ContactName = DisplayName;
            Title = title;
            Addresses = addresses;
        }
    }
}