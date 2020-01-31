using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.ResponseShards;
using Flurl.Http;
using Newtonsoft.Json.Linq;

namespace CS495_Capstone_Puma.Model
{
    public class ProposalGet
    {

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
                holding.AssetName = GetHoldingAssetName(cheetahConfig, holding.AssetId, bearerToken).Result;
                
            }

            return holdingsShards;
        }
        
        private IList<TradeShard> AddAssetNamesToTrades(CheetahConfig cheetahConfig, IList<TradeShard> tradeShards, string bearerToken)
        {
            foreach (TradeShard tradeShard in tradeShards)
            {
                tradeShard.AssetName = GetHoldingAssetName(cheetahConfig, tradeShard.AssetId, bearerToken).Result;
                
            }

            return tradeShards;
        }
        
        private async Task<string> GetHoldingAssetName(CheetahConfig cheetahConfig, int assetId, string bearerToken)
        {
            string response = await (cheetahConfig.ApiUrlRoot + "Assets?AssetId=" + assetId)
                .WithOAuthBearerToken(bearerToken)
                .GetStringAsync();
            JArray parsedResponseArray = JArray.Parse(response);
            JToken unarrayedParsedResponse = parsedResponseArray[0];
            JToken responseName = unarrayedParsedResponse["Issuer"];
            string nameString = responseName.ToString();
            return nameString;
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