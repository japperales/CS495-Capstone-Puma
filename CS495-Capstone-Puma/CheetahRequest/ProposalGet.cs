using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.ResponseShards;
using Flurl.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CS495_Capstone_Puma.Model
{
    public class ProposalGet
    {
        public async Task<Object[]> GetOriginalAndRevisedPortfolio(CheetahConfig cheetahConfig, string bearerToken, string accountId)
        {
            IList<HoldingsShard> currentPortfolio = await RetrieveOriginalPortfolio(cheetahConfig, bearerToken, accountId);
            
            IList<TradeShard> currentTrades = await RetrieveTradeProposal(cheetahConfig, bearerToken, accountId);
            
            IList<HoldingsShard> copiedPortfolio = new List<HoldingsShard>();
            
            foreach (HoldingsShard holding in currentPortfolio)
            {
                copiedPortfolio.Add(new HoldingsShard
                {
                    AssetId = holding.AssetId, AssetName = holding.AssetName, TotalAmount = holding.TotalAmount,
                    TotalValue = holding.TotalValue, AssetCategoryName = holding.AssetCategoryName,
                    PricePerShare = holding.PricePerShare
                });
            }
            IList<HoldingsShard> revisedPortfolio = await CompileNewPortfolio(cheetahConfig, bearerToken, copiedPortfolio, currentTrades);
            Console.WriteLine("CURRENT PORTFOLIO IS: " + JsonConvert.SerializeObject(currentPortfolio));
            Console.WriteLine("\n REVISED PORTFOLIO IS: " + JsonConvert.SerializeObject(revisedPortfolio));
            Console.WriteLine("Are the two portfolios the same?: " + (currentPortfolio.Equals(revisedPortfolio)));
            Object[] portfolios = new Object[2];
            portfolios[0] = currentPortfolio;
            portfolios[1] = revisedPortfolio;
            return portfolios;
        }

        private async Task<IList<HoldingsShard>> CompileNewPortfolio(CheetahConfig cheetahConfig, string bearerToken, IList<HoldingsShard> currentPortfolio, IList<TradeShard> currentTrades)
        {
            IList<HoldingsShard> revisedPortfolio = currentPortfolio.ToList();

            foreach (TradeShard trade in currentTrades)
            {
                if (trade.TradeTypeName == "Buy")
                {
                    revisedPortfolio = 
                        AddBoughtAssetToPortfolio(cheetahConfig, bearerToken, revisedPortfolio, trade);
                }
                else if (trade.TradeTypeName == "Sell")
                {
                    revisedPortfolio =
                        RemoveSoldAssetFromPortfolio(revisedPortfolio, trade);
                }
            }

            return revisedPortfolio;

        }

        private IList<HoldingsShard> RemoveSoldAssetFromPortfolio(IList<HoldingsShard> revisedPortfolio, TradeShard trade)
        {    IList<HoldingsShard> copiedPortfolio = revisedPortfolio.ToList();

            foreach (HoldingsShard holding in copiedPortfolio)
            {
                if (holding.AssetId == trade.AssetId)
                {
                    holding.TotalAmount -= trade.UnitShares;
                    holding.TotalValue -= (holding.PricePerShare * trade.UnitShares);
                    return copiedPortfolio;
                }
            }

            return null;
        }

        private IList<HoldingsShard> AddBoughtAssetToPortfolio(CheetahConfig cheetahConfig, string bearerToken, IList<HoldingsShard> revisedPortfolio, TradeShard trade)
        {
            IList<HoldingsShard> copiedPortfolio = revisedPortfolio.ToList();
            
            foreach (HoldingsShard holding in copiedPortfolio)
            {
                if (holding.AssetId == trade.AssetId)
                {    
                    holding.TotalAmount += trade.UnitShares;
                    holding.TotalValue += (holding.PricePerShare * trade.UnitShares);
                    return copiedPortfolio;
                }
            }

            HoldingsShard newHolding = CreateNewHoldingFromTrade(cheetahConfig, bearerToken, trade);
            copiedPortfolio.Add(newHolding);
            
            return copiedPortfolio;
        }

        private HoldingsShard CreateNewHoldingFromTrade(CheetahConfig cheetahConfig, string bearerToken, TradeShard trade)
        {
            AssetShard newAsset = GetAssetFromId(cheetahConfig, trade.AssetId, bearerToken).Result;
            
            HoldingsShard newHolding = 
                new HoldingsShard {AssetId = trade.AssetId, TotalAmount = trade.UnitShares, PricePerShare = newAsset.Price, AssetName = newAsset.Issuer, AssetCategoryName = newAsset.AssetCategoryDisplayName};

            return newHolding;
        }

        public async Task<IList<HoldingsShard>> RetrieveOriginalPortfolio(CheetahConfig cheetahConfig, string bearerToken, string accountId)
        {
            var response = await (cheetahConfig.ApiUrlRoot + "Accounts/" + accountId + "/Holdings")
                .WithOAuthBearerToken(bearerToken)
                .GetStringAsync();
        
            IList<HoldingsShard> holdings = ConvertHoldingTokenList(response);
            IList<HoldingsShard> namedHoldings = AddAssetNamesToHoldings(cheetahConfig, holdings, bearerToken);
            return namedHoldings;
        }

        public async Task<IList<TradeShard>> RetrieveTradeProposal(CheetahConfig cheetahConfig, string bearerToken, string accountId)
        {
            var response = await (cheetahConfig.ApiUrlRoot + "Trades?AccountId=" + accountId)
                .WithOAuthBearerToken(bearerToken)
                .GetStringAsync();
            
            IList<TradeShard> tradeList = ConvertTradeTokenList(response);
            tradeList = FilterTradesByTradeBatchId(0, tradeList);
            IList<TradeShard> namedTradeList = AddAssetNamesToTrades(cheetahConfig, tradeList, bearerToken);
            
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

        private IList<HoldingsShard> AddAssetNamesToHoldings(CheetahConfig cheetahConfig, IList<HoldingsShard> holdingsShards, string bearerToken)
        {
            foreach (HoldingsShard holding in holdingsShards)
            {
                AssetShard asset = GetAssetFromId(cheetahConfig, holding.AssetId, bearerToken).Result;
                holding.AssetName = asset.Issuer;

            }

            return holdingsShards;
        }
        
        private IList<TradeShard> AddAssetNamesToTrades(CheetahConfig cheetahConfig, IList<TradeShard> tradeShards, string bearerToken)
        {
            foreach (TradeShard tradeShard in tradeShards)
            {
                AssetShard asset = GetAssetFromId(cheetahConfig, tradeShard.AssetId, bearerToken).Result;
                tradeShard.AssetName = asset.Issuer;
            }

            return tradeShards;
        }
        
        private async Task<AssetShard> GetAssetFromId(CheetahConfig cheetahConfig, int assetId, string bearerToken)
        {
            string response = await (cheetahConfig.ApiUrlRoot + "Assets?AssetId=" + assetId)
                .WithOAuthBearerToken(bearerToken)
                .GetStringAsync();
            JArray parsedResponseArray = JArray.Parse(response);
            JToken unarrayedParsedResponse = parsedResponseArray[0];
            
            AssetShard assetShard = CreateAssetShard(unarrayedParsedResponse);
            return assetShard;
        }

        private AssetShard CreateAssetShard(JToken assetToken)
        {
            JToken pricePerShareToken = 0;
            if (assetToken["PriceHistories"] != null)
            {
                 pricePerShareToken = assetToken["PriceHistories"][0]["Price"];
            }

            float pricePerShare = float.Parse(pricePerShareToken.ToString());

            AssetShard asset = assetToken.ToObject<AssetShard>();

            asset.Price = pricePerShare;
            
            Console.WriteLine("Price per share is: " + asset.Price);
            Console.WriteLine("Asset ID is: " + asset.AssetId);
            Console.WriteLine("Display Name is: " + asset.AssetCategoryDisplayName);
            Console.WriteLine("Asset Name is: " + asset.Issuer);

            return asset;

        }

        private IList<HoldingsShard> ConvertHoldingTokenList(string jsonHoldingsString)
        {    
            IList<HoldingsShard> holdingShardList = new List<HoldingsShard>();

            JArray parsedResponse = JArray.Parse(jsonHoldingsString);
            JToken unarrayedHoldingsJson = parsedResponse[0];
            IList<JToken> holdingTokenList = unarrayedHoldingsJson["Holdings"].Children().ToList();
            
            foreach (JToken holdingToken in holdingTokenList)
            {
                HoldingsShard holdingShard = holdingToken.ToObject<HoldingsShard>();
                IList<JToken> lotTokenList = holdingToken["Lots"].Children().ToList();
                IList <LotShard> lotList = ConvertLotTokenList(lotTokenList);
                holdingShard.CalculateFieldsFromLots(lotList);
                holdingShardList.Add(holdingShard);
                
            }

            return holdingShardList;
        }

        private IList<LotShard> ConvertLotTokenList(IList<JToken> lotTokenList)
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