﻿using System.Collections.Generic;

namespace CS495_Capstone_Puma.DataStructure.IdentityRecord
{
    public class PhoneNumber
    {
        private string Number { get; set; }
        private int IdentityRecordId { get; set; }
        private int ContactMechanismId { get; set; }
        private string ContactMechanismType { get; set; }
        private string ContactMechanismIsUseType { get; set; }
        private bool IsPrimary { get; set; }
        private int MonthEffectiveFrom { get; set; }
        private int MonthEffectiveTo { get; set; }
        private int DayEffectiveFrom  { get; set; }
        private int DayEffectiveTo  { get; set; }
        private bool IsActive  { get; set; }
        private string Note  { get; set; }
        private List<string> ContactMechanismPurposeTypes { get; set; }
        private int InstitutionIdentityRecordId { get; set; }

        public PhoneNumber(string number, int identityRecordId, int contactMechanismId, string contactMechanismType, string contactMechanismIsUseType, bool isPrimary, int monthEffectiveFrom, int monthEffectiveTo, int dayEffectiveFrom, int dayEffectiveTo, bool isActive, string note, List<string> contactMechanismPurposeTypes, int institutionIdentityRecordId)
        {
            Number = number;
            IdentityRecordId = identityRecordId;
            ContactMechanismId = contactMechanismId;
            ContactMechanismType = contactMechanismType;
            ContactMechanismIsUseType = contactMechanismIsUseType;
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