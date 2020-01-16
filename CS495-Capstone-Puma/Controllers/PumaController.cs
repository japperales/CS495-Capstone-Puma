using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{    
    [Route("api/[controller]")]
    public class PumaController : Controller  
    {
        //Receive POST request addressed to HostingAddress/api/Puma. Deserializes JSON in HttpRequest body into assetInput Data Structure.
        [HttpPost]
        public JsonResult ProcessPost()
        {
            //Hardcoded assets
            List<AssetInput> assetInputs = new List<AssetInput>();
            assetInputs.Add(new AssetInput(new AssetIdentifier("33", "AAPL", "dd", ""), 10));
            assetInputs.Add(new AssetInput(new AssetIdentifier("33", "F", "dd", ""), 10));
            assetInputs.Add(new AssetInput(new AssetIdentifier("33", "NKE", "dd", ""), 10));
            
            //Instantiates class that communicates with Cheetah API
            CheetahHandler cheetah = new CheetahHandler();

            //Perform POSTs, preserving the bearerToken
            string bearerToken = cheetah.PostTransactions(assetInputs).Result;

           Object[] returnJson = cheetah.getTradeProposal(bearerToken, 1).Result;
            
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(returnJson);
        }
    }
} 


