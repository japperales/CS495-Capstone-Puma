using System;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.AccountResponse
{
    public class AccountRequest
    {
        public bool FailOnRelationshipLookup { get; set; }
        
        public string LegalName { get; set; }
        
        public string DisplayName { get; set; }

        public int DivisionIdentityRecordId { get; set; }
        
        public  int AccountCategoryId { get; set; }

        public string DateOpened { get; set; }

        public string DateEstablished { get; set; }

        public string Country { get; set; }
        
        public string StateProvince { get; set; }

        public string TaxIdStatusType { get; set; }

        public string TaxId { get; set; }
        
        public string TaxIdType { get; set; }
        
        public int OfficerId { get; set; }

        public string BeneficialOwnerTaxId { get; set; }

        public AccountRequest()
        {
            FailOnRelationshipLookup = true;
            LegalName = "Puma Account " + DateTime.Now.ToString("s");
            DisplayName = "Puma Account " + DateTime.Now.ToString("s");
            DivisionIdentityRecordId = 157;
            AccountCategoryId = 950;
            DateOpened = "2019-12-15T02:02:37.252Z";
            DateEstablished = "2019-12-15T02:02:37.252Z";
            Country = "UnitedStates";
            StateProvince = "Indiana";
            TaxIdStatusType = "Known";
            TaxId = "666123459";
            TaxIdType = "USSocialSecurityNumber";
            OfficerId = 1636;
            BeneficialOwnerTaxId = "666123456";
        }
    }
}