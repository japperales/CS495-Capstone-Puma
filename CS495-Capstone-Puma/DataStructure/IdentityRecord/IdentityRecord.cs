﻿using System;
 using System.Collections.Generic;
 using Newtonsoft.Json;

 namespace CS495_Capstone_Puma.DataStructure.IdentityRecord
{
    public class IdentityRecord
    {
        [JsonProperty("IdentityRecordId")]
        public long IdentityRecordId { get; set; }

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
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty("DateOfDeath")]
        public DateTimeOffset DateOfDeath { get; set; }

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
        public long InstitutionIdentityRecordId { get; set; }

        [JsonConstructor]
        public IdentityRecord(long identityRecordId, string code, string displayName, string payeeName, string taxIdStatusType, string taxId, string taxIdType, string domainModelClass, string comments, string salutationType, string genderType, string firstNameLegalName, string middleName, string lastName, string title, string contactName, DateTimeOffset dateOfBirth, DateTimeOffset dateOfDeath, List<ContactMethod> phoneNumbers, List<ContactMethod> emails, List<Address> addresses, List<string> identityClassificationTypes, bool isActive, long institutionIdentityRecordId)
        {
            IdentityRecordId = identityRecordId;
            Code = code;
            DisplayName = displayName;
            PayeeName = payeeName;
            TaxIdStatusType = taxIdStatusType;
            TaxId = taxId;
            TaxIdType = taxIdType;
            DomainModelClass = domainModelClass;
            Comments = comments;
            SalutationType = salutationType;
            GenderType = genderType;
            FirstNameLegalName = firstNameLegalName;
            MiddleName = middleName;
            LastName = lastName;
            Title = title;
            ContactName = contactName;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            PhoneNumbers = phoneNumbers;
            Emails = emails;
            Addresses = addresses;
            IdentityClassificationTypes = identityClassificationTypes;
            IsActive = isActive;
            InstitutionIdentityRecordId = institutionIdentityRecordId;
        }
    }
}