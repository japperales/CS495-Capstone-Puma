using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.Controllers
{   [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    public class PumaController : Controller 
    
    {
        CheetahHandler cheetah = new CheetahHandler();
        //Receive POST request addressed to HostingAddress/api/Puma. Deserializes JSON in HttpRequest body into assetInput Data Structure.
        [HttpPost("PostAssets")]
        public JsonResult ProcessPost([FromHeader] string jwt, [FromBody] List<AssetInput> assetInputs)
        {

            //Instantiates class that communicates with Cheetah API
            //CheetahHandler cheetah = new CheetahHandler();

            //Perform POSTs, preserving the bearerToken
            //string bearerToken = cheetah.PostTransactions(assetInputs, jwt).Result;

           Object[] returnJson = cheetah.getTradeProposal(jwt, "1").Result;
            Console.WriteLine("Return JSON is: " + JsonConvert.SerializeObject(returnJson));
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(returnJson);
        }

        [HttpPost("PostLogin")]
        [EnableCors("AllowAnyOrigin")]
        public  JsonResult RetrieveToken([FromBody] Login login)
        {
            TokenResponse tokenResponse = cheetah.PostAccessToken(login).Result;
            return Json(tokenResponse);
        }
    }
} 


