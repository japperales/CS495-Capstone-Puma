using System.IO;
using CS495_Capstone_Puma.DataStructure.Asset;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheetahApiSimulator.Controllers
{
    [ApiController]
    [Route("api/v6/[controller]")]
    public class AssetController : ControllerBase
    {
        [HttpGet] 
        public Asset Get() 
        {
            return buildAsset(0);
        }
        
        [HttpGet("{id}")]
        public Asset Get(int id)
        {
            return buildAsset(0);

        }

        [HttpPost]
        public Asset Post([FromBody] Asset asset)
        {
            using (StreamWriter file = System.IO.File.CreateText(@"Resources\Identity\"+asset.AssetId+".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, asset);
            }
            return asset;
        }

        public Asset buildAsset(int id)
        {
            using StreamReader file = System.IO.File.OpenText(@"Resources\Asset\"+id+".json");
            JsonSerializer serializer = new JsonSerializer();
            Asset asset = (Asset) serializer.Deserialize(file, typeof(Asset));

            return asset;
        }
    }
}