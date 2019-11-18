using System;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure.IdentityRecord;
using Flurl;
using Flurl.Http;

namespace CS495_Capstone_Puma.Model
{
    public class CheetahHandler
    {

        //Send Name & Address POST to Cheetah
        public IdentityRecord GetIdentityRecord(IdentityRecord identityRecord)
        {
            Task<IdentityRecord> test = getIdentityRecord(identityRecord);
            identityRecord = test.Result;
            return identityRecord;
        }
        public async Task<IdentityRecord> getIdentityRecord(IdentityRecord identityRecord)
        {
            IdentityRecord getResp = await "https://localhost:5002/api/v6/NameAndAddress".GetJsonAsync<IdentityRecord>();
            Console.Out.WriteLine(getResp.DisplayName);
            return getResp;
        }
            
        //Send Account POST to Cheetah
            
        //Send Account GET to Cheetah
        
        //Send other GET requests to Cheetah

        //Assemble objects into a Client object

        //return converted Client object
        
        
    }
}