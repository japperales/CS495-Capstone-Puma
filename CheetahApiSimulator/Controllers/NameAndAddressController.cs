using System.IO;
using CS495_Capstone_Puma.DataStructure.IdentityRecord;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheetahApiSimulator.Controllers
{
    [ApiController]
    [Route("api/v6/[controller]")]
    public class NameAndAddressController : ControllerBase
    {
        [HttpGet]
        public IdentityRecord Get()
        {
            return buildIdentity(0);
        }
        
        [HttpGet("{id}")]
        public IdentityRecord Get(int id)
        {
            return buildIdentity(id);
        }

        [HttpPost]
        public IdentityRecord Post([FromBody] IdentityRecord identityRecord)
        {
            using (StreamWriter file = System.IO.File.CreateText(@"Resources\Identity\"+identityRecord.IdentityRecordId+".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, identityRecord);
            }
            return identityRecord;
        }

        public IdentityRecord buildIdentity(int id)
        {
            using StreamReader file = System.IO.File.OpenText(@"Resources\Identity\"+id+".json");
            JsonSerializer serializer = new JsonSerializer();
            IdentityRecord identityRecord = (IdentityRecord) serializer.Deserialize(file, typeof(IdentityRecord));

            return identityRecord;
        }
    }
}