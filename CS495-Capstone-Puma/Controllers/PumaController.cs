using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{    
    [Route("api/[controller]")]
    public class PumaController : Controller
    {
        
        //Receive POST request addressed to HostingAddress/api/Puma. Deserializes JSON in HttpRequest body into assetInput Data Structure.
        [HttpPost]
        public JsonResult ProcessPost([FromBody] List<AssetInput> assetInputs)
        {
            //Instantiates class that communicates with Cheetah API
            CheetahHandler cheetah = new CheetahHandler();

            //Perform POSTs, preserving the bearerToken
            string bearerToken = cheetah.PostTransactions(assetInputs).Result;
            
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json("");
        }
    }
}


