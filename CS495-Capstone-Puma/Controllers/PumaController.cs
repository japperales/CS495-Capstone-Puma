using System;
using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{    
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
            jwt =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VyR3VpZCI6IjI3ZTNmNzM3LTRiMmItNGJmNC05ZWQ3LTJmMDJkNjQzN2IzNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJyYmFidXNpYWsiLCJleHAiOjE1ODAyNTQxNTIsImlzcyI6Imh0dHBzOi8vd3d3LnRydXN0YXNjLmNvbS8iLCJhdWQiOiJodHRwczovL3d3dy50cnVzdGFzYy5jb20vIn0.5oaSPwCZZ2epUjeNSJX8j8De9EyM9azwlE09aiLqabM";
            //string bearerToken = cheetah.PostTransactions(assetInputs, jwt).Result;

           Object[] returnJson = cheetah.getTradeProposal(jwt, "1").Result;
            
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(returnJson);
        }

        [HttpPost("PostLogin")]
        public JsonResult RetrieveToken([FromBody] Login login)
        {    login= new Login();
            login.Username = "***REMOVED***";
            login.Password = "***REMOVED***";
            TokenResponse tokenResponse = cheetah.PostAccessToken(login).Result;
            Console.WriteLine("Token for postlogin is: " + tokenResponse.Jwt);
            return Json(tokenResponse);
        }
    }
} 


