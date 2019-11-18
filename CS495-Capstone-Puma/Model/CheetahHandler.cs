﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.Account;
 using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public class CheetahHandler
    {

        //Main Handler Call
        public async Task<UIObject> postAndReceive(IdentityRecord identityRecord, Account account, List<Asset> assets)
        {
            await PostIdentityRecord(identityRecord);

            await PostAccount(account);

            foreach (Asset asset in assets)
            {
                await PostAsset(asset);
            }
            
            Asset adjustedAsset = GetAsset(2).Result;
            List<Asset> adjustedAssets = new List<Asset> {adjustedAsset};

            return new UIObject(identityRecord, adjustedAssets);
        }
        
        //Send Name & Address POST to Cheetah
        private async Task PostIdentityRecord(IdentityRecord identityRecord)
        {
            await "https://localhost:5002/api/v6/NameAndAddress".PostJsonAsync(identityRecord);
        }
        //Send Account POST to Cheetah
        private async Task PostAccount(Account account)
        {
            await "https://localhost:5002/api/v6/Account".PostJsonAsync(account);
        }
        
        //Sent Asset POST to Cheetah
        private async Task PostAsset(Asset asset)
        {
            await "https://localhost:5002/api/v6/Asset".PostJsonAsync(asset);
        }
        
        //Send Account GET to Cheetah
        private async Task<Asset> GetAsset(int id)
        {
            string api = "https://localhost:5002/api/v6/Account/" + id;
            Asset getResp = await api.GetJsonAsync<Asset>();
            
            return getResp;
        }
        
        //Send other GET requests to Cheetah

        //Assemble objects into a Client object

        //return converted Client object

    }
}