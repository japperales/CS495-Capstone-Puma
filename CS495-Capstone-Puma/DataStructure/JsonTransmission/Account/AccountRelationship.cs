using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class AccountRelationship
    {
        [JsonProperty("DomainModelClass")]
        public string DomainModelClass { get; set; }

        [JsonProperty("FirstNameLegalName")]
        public string FirstNameLegalName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("TaxIdStatusType")]
        public string TaxIdStatusType { get; set; }
        
        public AccountRelationship(string firstNameLegalName,string lastName, string displayName)
        {
            DomainModelClass = "IdentityRecord";
            FirstNameLegalName = firstNameLegalName;
            LastName = lastName;
            DisplayName = displayName;
            TaxIdStatusType = "NotUsed";
        }
    }
}