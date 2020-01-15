using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Flurl.Http.Testing;
using CS495_Capstone_Puma.Controllers;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.JsonRequest;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Flurl.Http;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.ControllersTest
{
    public class CheetahHandlerTest
    {
        
        private readonly ITestOutputHelper output;

        public CheetahHandlerTest(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void testPostAccessToken()
        {
            using (var httpTest = new HttpTest())
            {
                
                httpTest.RespondWithJson(new TokenResponse("djlkfaj3jlksj3e", 3599999,
                    "2020-01-13T17:58:47.142089Z", "2020-01-13T18:58:47.141089Z"));
                
                CheetahHandler cheetahHandler = new CheetahHandler();
                String test = cheetahHandler.postAccessToken().Result.Jwt;

                httpTest.ShouldHaveCalled("https://asctrustv57webapi.accutech-systems.net/api/v6/Token")
                    .WithVerb(HttpMethod.Post);
            }
        }

        [Fact]
        public async void testPostTransactionBatch()
        {
            CheetahHandler cheetahHandler = new CheetahHandler();
            string bearerToken = cheetahHandler.postAccessToken().Result.Jwt;
            TransactionBatchRequest request = new TransactionBatchRequest(1, "0", "PumaTest");
            
            
            TransactionBatchResponse postResp = await "https://asctrustv57webapi.accutech-systems.net/api/v6/TransactionBatches"
                .WithHeader("Content-Type", "application/json")
                .WithOAuthBearerToken(bearerToken)
                .PostJsonAsync(request)
                .ReceiveJson<TransactionBatchResponse>();

            output.WriteLine(postResp.ToString());

        }


        [Fact]
        public void testAssetDictionary()
        {
            CheetahHandler cheetahHandler = new CheetahHandler();

            string bearerToken = cheetahHandler.postAccessToken().Result.Jwt;
            
            Dictionary<AssetIdentifier, int> dictionary = cheetahHandler.populateAssetsDictionary(bearerToken);

            AssetIdentifier inputIden = new AssetIdentifier("38388292", "AAPL", "jaja", "Apple");
            AssetInput input = new AssetInput(inputIden, 10);

            Assert.Equal(196, dictionary[input.assetIdentifier]);
        }
    }
}