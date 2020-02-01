using System;
using System.Net.Http;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.Model;
using Flurl.Http.Testing;
using Xunit;

namespace CS495_Capstone_Puma.UnitTests.CheetahRequestTest
{
    public class HandlerLogicTests
    {

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
                    "2020-01-13T17:58:47.142089Z", "2020-01-13T18:58:47.141089Z"));
                
                CheetahHandler cheetahHandler = new CheetahHandler();
                String testToken = cheetahHandler.PostLogin(new Login("test","test"));

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
                
            CheetahHandler cheetahHandler = new CheetahHandler();
            String testToken = cheetahHandler.PostLogin(new Login("test","test"));

            httpTest.ShouldHaveCalled("*/Token")
                .WithVerb(HttpMethod.Post);
                
            Assert.Equal("badLogin", testToken);
        }
    }
}