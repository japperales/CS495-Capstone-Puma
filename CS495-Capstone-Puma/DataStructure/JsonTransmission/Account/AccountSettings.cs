using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure.Account
{
    public class AccountSettings
    {
        [JsonProperty("InvestmentObjectiveId")]
        public int InvestmentObjectiveId { get; set; }
        
        public AccountSettings(int investmentObjectiveId)
        {
            InvestmentObjectiveId = investmentObjectiveId;
            
        }
    }
}