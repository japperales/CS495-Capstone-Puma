using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;
using Flurl.Http.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.CheetahRequestTest
{
    public class HandlerLogicTests
    {
        
        private readonly ITestOutputHelper output;

        public HandlerLogicTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestLoadConfig()
        {
            CheetahHandler.LoadApiConfig();
        }

        [Fact]
        public void TestPostAccessToken()
        {
            using (var httpTest = new HttpTest())
            {
                
                httpTest.RespondWithJson(new TokenResponse("djlkfaj3jlksj3e", 3599999,
                    "2020-01-13T17:58:47.142089Z", "2020-01-13T18:58:47.141089Z", true));
                
                string testToken = CheetahHandler.PostLogin(new Login("test","test")).Jwt;

                httpTest.ShouldHaveCalled("*/Token")
                    .WithVerb(HttpMethod.Post);
                
                Assert.Equal("djlkfaj3jlksj3e", testToken);
            }
        }
        
        [Fact]
        public void TestBadPostAccessToken()
        {
            using var httpTest = new HttpTest();
            httpTest.RespondWith("",401);
            
            string testToken = CheetahHandler.PostLogin(new Login("test","test")).Jwt;

            httpTest.ShouldHaveCalled("*/Token")
                .WithVerb(HttpMethod.Post);
                
            Assert.Null(testToken);
        }

        [Fact]
        public void ElevatedTestPostAccessToken()
        {
            output.WriteLine("This test communicates with the Cheetah API. Elevated permissions are required to test this.");

            Login login = LoadLogin();

            string bearerToken = CheetahHandler.PostLogin(login).Jwt;
            
            Assert.NotNull(bearerToken);
        }
        
        [Fact]
        public void ElevatedTestPostAssets()
        {
            output.WriteLine("This test communicates with the Cheetah API. Elevated permissions are required to test this.");

            Login login = LoadLogin();

            string bearerToken = CheetahHandler.PostLogin(login).Jwt;

            AssetInput assetInput = new AssetInput(new AssetIdentifier("","AAPL","",""), 12);
            List<AssetInput> assets = new List<AssetInput>{assetInput};
            

            string resp = CheetahHandler.PostAssets(bearerToken, assets).Result;
            Assert.Equal("PostAssets Successful", resp);
        }
        
        [Fact]
        public void ElevatedTestBadPostAssets()
        {
            output.WriteLine("This test communicates with the Cheetah API. Elevated permissions are required to test this.");

            Login login = LoadLogin();

            string bearerToken = CheetahHandler.PostLogin(login).Jwt;
            Assert.NotNull(bearerToken);
            
            List<AssetInput> assets = new List<AssetInput>();

            string resp = CheetahHandler.PostAssets(bearerToken, assets).Result;
            
            Assert.Equal("PostAssets Error", resp);
        }
        
        
        public static Login LoadLogin()
        {
            using (StreamReader file = File.OpenText(@"..\\..\\..\\login.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Login login = (Login) serializer.Deserialize(file, typeof(Login));
                return login;
            }
        }
    }
}