 ﻿using System;
 using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
 using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.Account;
 using CS495_Capstone_Puma.DataStructure.Asset;
 using CS495_Capstone_Puma.DataStructure.JsonTransmission;
 using CS495_Capstone_Puma.DataStructure.JsonResponse;
  using CS495_Capstone_Puma.DataStructure.JsonTransmission.NameAndAddress;
  using CS495_Capstone_Puma.DataStructure.NameAndAddress;
 using Flurl.Http;
 using AccountRelationship = CS495_Capstone_Puma.DataStructure.JsonTransmission.AccountRelationshipPOST;
  
  namespace CS495_Capstone_Puma.Controllers 
  {
    public class CheetahHandler
    {

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task PostAndReceive(IdentityRecord identityRecord, Account account, List<Asset> assets)
        {
            //POST Authentication
            String bearerToken = POSTAccessToken().Result.Jwt;

            //POST IdentityRecord & Account async
            Task<NameAndAddressesResponse> postIdentityRecord = POSTIdentityRecord(bearerToken, identityRecord);
            Task<AccountResponse> postAccount = POSTAccount(bearerToken, account);
            
            //await completion and assign values when ready
            List<Task> allTasks = new List<Task>{postAccount, postIdentityRecord};
            int identityRecordId = 0;
            int accountId = 0;
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == postIdentityRecord)
                {
                    identityRecordId = postIdentityRecord.Result.IdentityRecordId;
                }
                else if (finished == postAccount)
                {
                    accountId = postAccount.Result.AccountId;
                }
                allTasks.Remove(finished);
            }

            //POST Owner relationship
            Task postOwnerRelationship = POSTOwnerRelationship(bearerToken, accountId, identityRecordId);
            allTasks.Add(postOwnerRelationship);
            
            //POST Open
            
            
            //POST Transactions (Assets already owned)
              //Some kind of FOR loop
              //Iterates to send a POST
              //allTasks.Add(thatpost)
            
            
            //await completion
            await Task.WhenAll(allTasks);

            //***Cannot Analyze Yet***
            
            
            //GET Trades
            

            //Return all trades
            
        }
        
        //POST Authentication Login and receive Bearer Token
        public async Task<TokenResponse> POSTAccessToken()
        {
            TokenResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Token"
                .WithHeader("x-api-key", 
                    "DELETE BEFORE VERSIONING"
                    )
                .WithBasicAuth("DELETE BEFORE VERSIONING", "DELETE BEFORE VERSIONING")
                .PostAsync(null)
                .ReceiveJson<TokenResponse>();
                    
            return postResp;
        } 
        
        //POST Name & Address to IdentityRecord
        public async Task<NameAndAddressesResponse> POSTIdentityRecord(string bearerToken, IdentityRecord identityRecord)
        {
            NameAndAddressesResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/NameAndAddresses"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PutJsonAsync(identityRecord)
                .ReceiveJson<NameAndAddressesResponse>();
                    
            return postResp;
        }
        
        //POST Account Information
        private async Task<AccountResponse> POSTAccount(string bearerToken, Account account)
        {
            AccountResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Account"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PutJsonAsync(account)
                .ReceiveJson<AccountResponse>();

            return postResp;
        }
        
        //POST the Administrator relationship on new account ~Currently Not Being Used~
        public static async Task POSTAdminRelationship(string bearerToken, int accountId)
        { 
            AccountRelationship accountRelationship = new AccountRelationshipPOST(accountId);
            
            await "https://asctrustv57webapi.accutech-systems.net/api/v6/AccountRelationships"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PutJsonAsync(accountRelationship)
                .ReceiveJson();
        }
        
        //POST the Owner relationship on new account
        public static async Task POSTOwnerRelationship(string bearerToken, int accountId, int identityRecordId)
        {
            AccountRelationshipPOST accountRelationship = new AccountRelationshipPOST(accountId, identityRecordId);
            
            await "https://asctrustv57webapi.accutech-systems.net/api/v6/AccountRelationships"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PutJsonAsync(accountRelationship)
                .ReceiveJson();
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
    }
}