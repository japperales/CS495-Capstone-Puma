using System;
using System.Net.Http;
using Flurl.Http.Testing;
using CS495_Capstone_Puma.Controllers;
using CS495_Capstone_Puma.DataStructure;
using Xunit;

namespace CS495_Capstone_Puma.UnitTests.ControllersTest
{
    public class CheetahHandlerTest
    {

        [Fact]
        public void TestPostAccessToken()
        {
            using (var httpTest = new HttpTest())
            {
                
                httpTest.RespondWithJson(new TokenResponse("djlkfaj3jlksj3e", 3599999,
                    "2020-01-13T17:58:47.142089Z", "2020-01-13T18:58:47.141089Z"));
                String test = CheetahHandler.GetAccessToken().Result.Jwt;

                httpTest.ShouldHaveCalled("https://asctrustv57webapi.accutech-systems.net/Api/v6/Token")
                    .WithVerb(HttpMethod.Post);
            }
        }
        
        
    }
}