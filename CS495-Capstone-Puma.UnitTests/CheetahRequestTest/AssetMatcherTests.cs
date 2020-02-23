using System.Collections.Generic;
using System.IO;
using CS495_Capstone_Puma.AutoFill;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.CheetahRequestTest
{
    public class AssetMatcherTests
    {
        private readonly ITestOutputHelper output;

        public AssetMatcherTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MatchFiveResultsTest()
        {
            Login login = LoadLogin();
            string bearerToken = CheetahHandler.PostLogin(login).Jwt;
            Assert.NotNull(bearerToken);

            AssetMatcher.UpdateAssets(bearerToken);
            

            List<AssetLookupResponse> results = AssetMatcher.GetMatches("A");
            foreach (AssetLookupResponse result in results)
            {
                output.WriteLine(result.value.issuer);
            }
            Assert.Equal(5, results.Count);
        }
        
        [Fact]
        public void MatchLessThanFiveResultsTest()
        {
            Login login = LoadLogin();
            string bearerToken = CheetahHandler.PostLogin(login).Jwt;
            Assert.NotNull(bearerToken);

            AssetMatcher.UpdateAssets(bearerToken);
            

            List<AssetLookupResponse> results = AssetMatcher.GetMatches("Ap");
            foreach (AssetLookupResponse result in results)
            {
                output.WriteLine(result.value.issuer);
            }
            Assert.Equal(2, results.Count);
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