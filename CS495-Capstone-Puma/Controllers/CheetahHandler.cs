﻿using System;
 using System.Collections.Generic;
 using System.Net.Http;
 using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.Account;
 using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using Flurl.Http;

namespace CS495_Capstone_Puma.Controllers
{
    public class CheetahHandler
    {

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<UIObject> PostAndReceive(IdentityRecord identityRecord, Account account, List<Asset> assets)
        {
            //POST Authentication
            String accessToken = PostAccessToken().Result.Jwt;

            //POST IdentityRecord & Account async
            PostIdentityRecord(identityRecord);
            PostAccount(account);
            
            //POST Owner & Admin relationships
            
            
            //POST Transactions (Assets already owned)
            
            
            //***Cannot Analyze Yet**
            
            
            //GET Trades
            
            
            //Return all trades

            
            
            
            //OLD
            
            await PostIdentityRecord(identityRecord);

            await PostAccount(account);

            //Hacked Methodology while using API simulation instead of actual Cheetah
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
        
        //Send Asset GET to Cheetah
        private async Task<Asset> GetAsset(int id)
        {
            string api = "https://localhost:5002/api/v6/Asset/" + id;
            Asset getResp = await api.GetJsonAsync<Asset>();
            
            return getResp;
        }
        
        public static async Task<TokenResponse> PostAccessToken()
        {
            TokenResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/Api/v6/Token"
                .WithHeader("x-api-key",
                    "DELETE BEFORE VERSIONING"
                    )
                .WithBasicAuth("DELETE BEFORE VERSIONING", "DELETE BEFORE VERSIONING")
                .PostJsonAsync(new {})
                .ReceiveJson<TokenResponse>();
            
            return postResp;
        }
    }
}