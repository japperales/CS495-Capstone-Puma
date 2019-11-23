using System;
using Newtonsoft.Json;

namespace CheetahApiSimulator.DataStructure.Account
{
    public class AccountRelationship
    {
        [JsonProperty("DomainModelClass")]
        public string DomainModelClass { get; set; }

        [JsonProperty("FirstNameLegalName")]
        public string FirstNameLegalName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("ContactName")]
        public string ContactName { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("PayeeName")]
        public string PayeeName { get; set; }

        [JsonProperty("SalutationType")]
        public string SalutationType { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("GenderType")]
        public string GenderType { get; set; }

        [JsonProperty("DateOfBirth")]
        public DateTimeOffset DateOfBirth { get; set; }

        [JsonProperty("DateOfDeath")]
        public DateTimeOffset DateOfDeath { get; set; }

        [JsonProperty("TaxIdStatusType")]
        public string TaxIdStatusType { get; set; }

        [JsonProperty("TaxIdType")]
        public string TaxIdType { get; set; }

        [JsonProperty("TaxId")]
        public string TaxId { get; set; }

        [JsonProperty("Comments")]
        public string Comments { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("PhoneNumberContactMechanismUseType")]
        public string PhoneNumberContactMechanismUseType { get; set; }

        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("EmailContactMechanismUseType")]
        public string EmailContactMechanismUseType { get; set; }

        [JsonProperty("PrimaryAddressAttention")]
        public string PrimaryAddressAttention { get; set; }

        [JsonProperty("PrimaryAddressLine1")]
        public string PrimaryAddressLine1 { get; set; }

        [JsonProperty("PrimaryAddressLine2")]
        public string PrimaryAddressLine2 { get; set; }

        [JsonProperty("PrimaryAddressLine3")]
        public string PrimaryAddressLine3 { get; set; }

        [JsonProperty("PrimaryAddressCity")]
        public string PrimaryAddressCity { get; set; }

        [JsonProperty("PrimaryAddressStateProvince")]
        public string PrimaryAddressStateProvince { get; set; }

        [JsonProperty("PrimaryAddressCountry")]
        public string PrimaryAddressCountry { get; set; }

        [JsonProperty("PrimaryAddressPostalCode")]
        public string PrimaryAddressPostalCode { get; set; }

        [JsonProperty("PrimaryAddressContactMechanismUseType")]
        public string PrimaryAddressContactMechanismUseType { get; set; }
        
        [JsonConstructor]
        public AccountRelationship(string domainModelClass, string firstNameLegalName, string middleName, string lastName, string code, string contactName, string displayName, string payeeName, string salutationType, string title, string genderType, DateTimeOffset dateOfBirth, DateTimeOffset dateOfDeath, string taxIdStatusType, string taxIdType, string taxId, string comments, string phoneNumber, string phoneNumberContactMechanismUseType, string emailAddress, string emailContactMechanismUseType, string primaryAddressAttention, string primaryAddressLine1, string primaryAddressLine2, string primaryAddressLine3, string primaryAddressCity, string primaryAddressStateProvince, string primaryAddressCountry, string primaryAddressPostalCode, string primaryAddressContactMechanismUseType)
        {
            DomainModelClass = domainModelClass;
            FirstNameLegalName = firstNameLegalName;
            MiddleName = middleName;
            LastName = lastName;
            Code = code;
            ContactName = contactName;
            DisplayName = displayName;
            PayeeName = payeeName;
            SalutationType = salutationType;
            Title = title;
            GenderType = genderType;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            TaxIdStatusType = taxIdStatusType;
            TaxIdType = taxIdType;
            TaxId = taxId;
            Comments = comments;
            PhoneNumber = phoneNumber;
            PhoneNumberContactMechanismUseType = phoneNumberContactMechanismUseType;
            EmailAddress = emailAddress;
            EmailContactMechanismUseType = emailContactMechanismUseType;
            PrimaryAddressAttention = primaryAddressAttention;
            PrimaryAddressLine1 = primaryAddressLine1;
            PrimaryAddressLine2 = primaryAddressLine2;
            PrimaryAddressLine3 = primaryAddressLine3;
            PrimaryAddressCity = primaryAddressCity;
            PrimaryAddressStateProvince = primaryAddressStateProvince;
            PrimaryAddressCountry = primaryAddressCountry;
            PrimaryAddressPostalCode = primaryAddressPostalCode;
            PrimaryAddressContactMechanismUseType = primaryAddressContactMechanismUseType;
        }
    }
}