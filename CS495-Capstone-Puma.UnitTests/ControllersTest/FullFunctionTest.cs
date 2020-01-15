using System.Collections.Generic;
using CS495_Capstone_Puma.Controllers;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.ControllersTest
{
    public class FullFunctionTest
    {
        private readonly ITestOutputHelper output;

        public FullFunctionTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void testFullFunctionality()
        {
            CheetahHandler cheetah = new CheetahHandler();

            List<AssetInput> inputs = new List<AssetInput>();
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","AAPL","asd","asdf"), 19));
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","F","asd","asdf"), 3));
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","NKE","asd","asdf"), 129));

            output.WriteLine(cheetah.PostTransactions(inputs).Result);
        }
    }
}