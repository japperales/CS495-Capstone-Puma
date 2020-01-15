﻿﻿using System;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;
 using System.Net.Http;
 using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.Account;
 using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
 using CS495_Capstone_Puma.DataStructure.ResponseShards;
 using Flurl.Http;
 using Microsoft.Extensions.Logging;
 using Newtonsoft.Json.Linq;

 namespace CS495_Capstone_Puma.Controllers
{
    public class CheetahHandler
    {

        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<Object[]> PostAndReceive(IdentityRecord identityRecord, Account account, List<Asset> assets)
        {
            //POST Authentication
            string accessToken = GetAccessToken().Result.Jwt;
            //Console.WriteLine("Hey look it's an access token! its right here: " + accessToken);
            //POST IdentityRecord & Account async

            IList<HoldingsShard> originalPortfolio = RetrieveOriginalPortfolio(accessToken).Result;


            IList<TradeShard> tradeProposal = RetrieveTradeProposal(accessToken).Result;
            
            Object[] responseArray = new Object[4];
            responseArray[0] = originalPortfolio;
            responseArray[1] = tradeProposal;
            responseArray[2] = 484934.46;
            responseArray[3] = 5891.01;

            return responseArray;
            //PostIdentityRecord(identityRecord);
            //PostAccount(account);
            
            //POST Owner & Admin relationships
            
            
            //POST Transactions (Assets already owned)
            
            
            //***Cannot Analyze Yet**
            
            
            //GET Trades
            
            
            //Return all trades

            
            
            
            //OLD
            
            //await PostIdentityRecord(identityRecord);

            //await PostAccount(account);

            //Hacked Methodology while using API simulation instead of actual Cheetah
            //Asset adjustedAsset = GetAsset(2).Result;
            //List<Asset> adjustedAssets = new List<Asset> {adjustedAsset};

            return null;
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
        {    //"DELETE BEFORE VERSIONING"
            TokenResponse response = await "https://asctrustv57webapi.accutech-systems.net/Api/v6/Token"
                .WithHeader("x-api-key",
                    "mGamIPYtegnxNTXJcveWhWIJFIfOpM9ZDls33nrpTKfLvAhmSZRhkZvOwsUCWeryNvh8MCQOfVRNXAwNMJ6eRGK62rJJfXhW8RZHWcQvdFt2cki12t1YcvP4TgNvjL9V"
                    )
                .WithBasicAuth("rbabusiak", "P@ssw0rd1")
                .PostJsonAsync(new {})
                .ReceiveJson<TokenResponse>();
            
            return response;
        }
        
        private static async Task<IList<HoldingsShard>> RetrieveOriginalPortfolio(string jwt)
        {
            var response = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Accounts/1/Holdings"
                .WithOAuthBearerToken(jwt)
                .GetStringAsync();

            IList<HoldingsShard> holdings = ConvertHoldingTokenList(response);
            IList<HoldingsShard> namedHoldings = AddAssetNamesToHoldings(holdings, jwt);
            return namedHoldings;
        }

        private static async Task<IList<TradeShard>> RetrieveTradeProposal(string jwt)
        {
            var response = await "https://asctrustv57webapi.accutech-systems.net/Api/v6/Trades?AccountId=1"
                .WithOAuthBearerToken(jwt)
                .GetStringAsync();
            
            IList<TradeShard> tradeList = ConvertTradeTokenList(response);
            tradeList = FilterTradesByTradeBatchId(0, tradeList);
            IList<TradeShard> namedTradeList = AddAssetNamesToTrades(tradeList, jwt);
            
            return namedTradeList;
        }

        private static IList<TradeShard> ConvertTradeTokenList(string response)
        {
            JArray parsedTrades = JArray.Parse(response);
            IList<JToken> tradeTokens = parsedTrades.Children().ToList();
            IList<TradeShard> tradeList = new List<TradeShard>();
            foreach (JToken tradeToken in tradeTokens)
            {
                TradeShard tradeShard = tradeToken.ToObject<TradeShard>();
                tradeList.Add(tradeShard);
            }
            return tradeList;
        }

        private static IList<TradeShard>  FilterTradesByTradeBatchId(int tradeBatchId, IList<TradeShard> tradeList)
        {
            for (int i = 0; i < tradeList.Count; i++)
            {
                if (tradeList[i].TradeBlockId != tradeBatchId)
                {
                    tradeList.Remove(tradeList[i]);
                }
            }

            return tradeList;
        }

        private static IList<HoldingsShard> AddAssetNamesToHoldings(IList<HoldingsShard> holdingsShards, string jwt)
        {
            foreach (HoldingsShard holding in holdingsShards)
            {
                holding.AssetName = GetHoldingAssetName(holding.AssetId, jwt).Result;
                Console.WriteLine(holding.AssetName);
            }

            return holdingsShards;
        }
        
        private static IList<TradeShard> AddAssetNamesToTrades(IList<TradeShard> tradeShards, string jwt)
        {
            foreach (TradeShard tradeShard in tradeShards)
            {
                tradeShard.AssetName = GetHoldingAssetName(tradeShard.AssetId, jwt).Result;
                Console.WriteLine(tradeShard.AssetName);
            }

            return tradeShards;
        }
        
        private static async Task<string> GetHoldingAssetName(int assetId, string jwt)
        {
            var response = await ("https://asctrustv57webapi.accutech-systems.net/api/v6/Assets?AssetId=" + assetId)
                .WithOAuthBearerToken(jwt)
                .GetStringAsync();
            JArray parsedResponseArray = JArray.Parse(response);
            var unarrayedParsedResponse = parsedResponseArray[0];
            JToken responseName = unarrayedParsedResponse["Issuer"];
            string nameString = responseName.ToString();
            return nameString;
        }
        
        private static IList<HoldingsShard> ConvertHoldingTokenList(string jsonHoldingsString)
        {    
            IList<HoldingsShard> holdingShardList = new List<HoldingsShard>();

            JArray parsedResponse = JArray.Parse(jsonHoldingsString);
            var unarrayedHoldingsJson = parsedResponse[0];
            IList<JToken> holdingTokenList = unarrayedHoldingsJson["Holdings"].Children().ToList();
            
            foreach (JToken holdingToken in holdingTokenList)
            {
                HoldingsShard holdingShard = holdingToken.ToObject<HoldingsShard>();
                IList<JToken> lotTokenList = holdingToken["Lots"].Children().ToList();
                IList <LotShard> LotList = ConvertLotTokenList(lotTokenList);
                holdingShard.CalculateFieldsFromLots(LotList);
                holdingShardList.Add(holdingShard);
                
            }

            return holdingShardList;
        }

        private static IList<LotShard> ConvertLotTokenList(IList<JToken> lotTokenList)
        {
            IList<LotShard> lotList = new List<LotShard>();
            
            foreach (JToken lotToken in lotTokenList)
            {
                LotShard lotObject = lotToken.ToObject<LotShard>();
                lotList.Add(lotObject);
            }
            
            return lotList;
        }

    }
    
}