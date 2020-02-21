using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CS495_Capstone_Puma.Controllers
{   
    
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    public class PumaController : Controller
    {
        //Global object used to communicate with Cheetah Api
        private readonly CheetahHandler _cheetah = new CheetahHandler();
        
        //Receive POST addressed to HostingAddress/api/Puma/PostLogin
        //Attempt Login and return bearer token
        [HttpPost("PostLogin")]
        [EnableCors("AllowAnyOrigin")]
        public  JsonResult PostLogin([FromBody] Login login)
        {
            TokenResponse bearerToken = _cheetah.PostLogin(login);
            return Json(bearerToken);
        }

        //Receive POST request addressed to HostingAddress/api/Puma/PostAssets.
        //Deserializes JSON in HttpRequest body into assetInput Data Structure.
        [HttpPost("PostAssets")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult PostAssets([FromHeader] string jwt, [FromBody] List<AssetInput> assetInputs)
        {
            Console.WriteLine("jwt is: " + jwt);
            //Perform POSTs, preserving the bearerToken
            string bearerToken = _cheetah.PostAssets(jwt, assetInputs).Result;
            
            Object[] returnJson = _cheetah.GetTradeProposal(jwt, "1");
            Console.WriteLine("Return JSON is: " + JsonConvert.SerializeObject(returnJson));
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(returnJson);
        }

        
    }
} 


