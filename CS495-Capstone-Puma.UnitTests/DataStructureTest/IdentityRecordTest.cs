using System;
using System.Diagnostics;
using System.IO;
using CS495_Capstone_Puma.DataStructure.IdentityRecord;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.DataStructureTest
{
    public class IdentityRecordTest
    {
        private readonly ITestOutputHelper output;

        public IdentityRecordTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        void CreateIdentityRecordTest()
        {
            using (StreamReader file = File.OpenText(@"D:\RiderProjects\CS495-Capstone-Puma\CS495-Capstone-Puma.UnitTests\Resources\IdentityRecord.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                IdentityRecord identityRecord = (IdentityRecord) serializer.Deserialize(file, typeof(IdentityRecord));
                output.WriteLine(identityRecord.ContactName);
            }
        }
    }
}