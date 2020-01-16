using System.Collections.Generic;
using CS495_Capstone_Puma.Controllers;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.ControllersTest
{
    public class FullFunctionTest
    {
        private readonly ITestOutputHelper _output;

        public FullFunctionTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestFullFunctionality()
        {
            CheetahHandler cheetah = new CheetahHandler();

            List<AssetInput> inputs = new List<AssetInput>();
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","AAPL","asd","asdf"), 19));
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","F","asd","asdf"), 3));
            
            inputs.Add(new AssetInput(
                new AssetIdentifier("2342","NKE","asd","asdf"), 129));

            _output.WriteLine(cheetah.PostTransactions(inputs).Result);
        }
    }
}