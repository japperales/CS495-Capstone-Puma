﻿using System;
 using System.Collections.Generic;
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

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<UIObject> PostAndReceive(IdentityRecord identityRecord, Account account, List<Asset> assets)
        {
            TokenResponse accessToken = await GetAccessToken();

            Console.WriteLine(accessToken.Jwt);
            
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

        public static async Task<TokenResponse> GetAccessToken()
        {

            TokenResponse token = await "https://asctrustv57webapi.accutech-systems.net/Api/v6/Token"
                .WithHeader("x-api-key",
                    "mGamIPYtegnxNTXJcveWhWIJFIfOpM9ZDls33nrpTKfLvAhmSZRhkZvOwsUCWeryNvh8MCQOfVRNXAwNMJ6eRGK62rJJfXhW8RZHWcQvdFt2cki12t1YcvP4TgNvjL9V"
                    )
                .WithBasicAuth("INSERT USERNAME HERE", "INSERT PASSWORD HERE")
                .GetJsonAsync<TokenResponse>();
            return token;

        }
    }
}