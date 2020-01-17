 using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Threading.Tasks;
 using CS495_Capstone_Puma.DataStructure;
 using CS495_Capstone_Puma.DataStructure.Asset;
  using CS495_Capstone_Puma.DataStructure.JsonRequest;
  using CS495_Capstone_Puma.DataStructure.JsonResponse;
  using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
 using CS495_Capstone_Puma.DataStructure.ResponseShards;
 using Flurl;
  using Flurl.Http;
 using Newtonsoft.Json;
 using Newtonsoft.Json.Linq;

 namespace CS495_Capstone_Puma.Controllers 
  {
    public class CheetahHandler
    {
        //Coordinates the POST and GET HttpRequests required by the process.
        public async Task<string> PostTransactions(List<AssetInput> assets)
        {
            //POST Authentication
            String bearerToken = postAccessToken().Result.Jwt;
            
            //POST TransactionBatch
            int batchId = postTransactionBatch(bearerToken, new TransactionBatchRequest()).Result.transactionBatchId;

            //POST Transactions (Assets already owned)

            List<TransactionRequest> transactions = assembleTransactions(bearerToken, batchId, assets);
            
            foreach (TransactionRequest transaction in transactions)
            {
                await postTransaction(bearerToken, transaction);
            }
            
            await postTransactionBatchProcessor(bearerToken, batchId, false);
            await postTransactionBatchProcessor(bearerToken, batchId, true);
            
            //Cannot Analyze yet - have to make a second function
            //return relevant info to keep using it
            return bearerToken;
        }

        public async Task<Object[]> getTradeProposal(string bearerToken, int accountId)
        {
            //await getTrades(bearerToken, accountId);
            
            IList<HoldingsShard> originalPortfolio = RetrieveOriginalPortfolio(bearerToken).Result;
            
            IList<TradeShard> tradeProposal = RetrieveTradeProposal(bearerToken).Result;
            
            Object[] responseArray = new Object[4];
            responseArray[0] = originalPortfolio;
            responseArray[1] = tradeProposal;
            responseArray[2] = 484934.46;
            responseArray[3] = 5891.01;

            return responseArray;
        }
        
        //POST Authentication login and receive Bearer Token
        public async Task<TokenResponse> postAccessToken()
        {
            Login login = new Login();
            using (StreamReader file = File.OpenText(@".\\login.json"))
            
            {
                JsonSerializer serializer = new JsonSerializer();
                login = (Login) serializer.Deserialize(file, typeof(Login));
            }

            TokenResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Token"
                .WithHeader("x-api-key", login.XApiKey
                )
                .WithBasicAuth(login.Username, login.Password)
                .PostAsync(null)
                .ReceiveJson<TokenResponse>();
                    
            return postResp;
        }
        
        //POST TransactionBatch
        public async Task<TransactionBatchResponse> postTransactionBatch(string bearerToken, TransactionBatchRequest request)
        {
            TransactionBatchResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionBatchResponse>();

            return postResp;
        }
        
        //POST Transaction
        private async Task<TransactionResponse> postTransaction(string bearerToken, TransactionRequest request)
        {
            TransactionResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Transactions/Pending"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionResponse>();

            return postResp;
        }

        //POST TransactionBatch Ready & Post commands
        private async Task postTransactionBatchProcessor(string bearerToken, int batchId, bool isReadied)
        {
            string urlSuffix = "";
            
            if (!isReadied)
            {
                urlSuffix = "/Ready";
            }
            else
            {
                urlSuffix = "/Post";
            }
            
            await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .AppendPathSegment(urlSuffix)
                .SetQueryParam("TransactionBatchIds",batchId)
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostAsync(null);
        }
        
        //GET analyzed Trade suggestions
        private async Task<TradeResponse> getTrades(string bearerToken, int accountId)
        {
            TradeResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Accounts"
                .AppendPathSegment(accountId)
                .AppendPathSegment("Trades")
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .GetAsync()
                .ReceiveJson<TradeResponse>();

            return postResp;
        }
        
        //Assemble list of Transactions from Assets list
        private List<TransactionRequest> assembleTransactions(string bearerToken, int batchId, List<AssetInput> assets)
        {
            //Populate Dictionary of assets from Cheetah with a GET request
            Dictionary<AssetIdentifier, int> allAssets = populateAssetsDictionary(bearerToken);
            
            //Instantiate TransactionRequest List
            List<TransactionRequest> transactionRequests = new List<TransactionRequest>();
            
            //for each asset in assets, check for entry in Dict
            foreach (AssetInput asset in assets)
            {
                try
                {
                    int assetId = allAssets[asset.assetIdentifier];
                    
                    //Once found, build request and POST to the batch
                    transactionRequests.Add(new TransactionRequest(
                        534, batchId, 26, 19, assetId, asset.units));
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine("Key not found");
                }
            }
            return transactionRequests;
        }

        public Dictionary<AssetIdentifier, int> populateAssetsDictionary(string bearerToken)
        {
            Dictionary<AssetIdentifier, int> assetsDictionary =
                new Dictionary<AssetIdentifier, int>(new AssetIdentifier.AssetEqualityComparer());
            
            List<AssetLookupResponse> assetLookupResponses = getLookupAssets(bearerToken).Result.items;
            
            foreach (AssetLookupResponse assetLookupResponse in assetLookupResponses)
            {
                try
                {
                    assetsDictionary.Add(assetLookupResponse.value, Int32.Parse(assetLookupResponse.id));
                }
                catch (ArgumentException){}
            }
            return assetsDictionary;
        }

        private async Task<LookupResponse> getLookupAssets(string bearerToken)
        {
            LookupResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/Lookup?LookupService=GetAssetValues"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .GetAsync()
                .ReceiveJson<LookupResponse>();

            return postResp;
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