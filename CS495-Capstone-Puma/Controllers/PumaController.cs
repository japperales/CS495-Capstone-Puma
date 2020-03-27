using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
using CS495_Capstone_Puma.AutoFill;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.AccountResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using CS495_Capstone_Puma.DataStructure.BoundingBoxes;
using CS495_Capstone_Puma.DataStructure.Images;

namespace CS495_Capstone_Puma.Controllers
{   
    
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    public class PumaController : Controller
    {
        //Receive POST addressed to HostingAddress/api/Puma/PostLogin
        //Attempt Login and return bearer token
        [HttpPost("PostLogin")]
        [EnableCors("AllowAnyOrigin")]
        public  JsonResult PostLogin([FromBody] Login login)
        {
            TokenResponse bearerToken = CheetahHandler.PostLogin(login);
            AssetMatcher.UpdateAssets(bearerToken.Jwt);
            return Json(bearerToken);
        }

        //Receive POST request addressed to HostingAddress/api/Puma/PostAssets.
        //Deserializes JSON in HttpRequest body into assetInput Data Structure.
        [HttpPost("PostAssets")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult PostAssets([FromHeader] string jwt, [FromBody] List<AssetInput> assetInputs)
        {
            Console.WriteLine("jwt in post assets in puma controller is: " + jwt);
            //Perform POSTs, preserving the bearerToken
            AccountResponse accountResponse= CheetahHandler.PostAssets(jwt, assetInputs).Result;
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(accountResponse);
        }
        
        [HttpGet("RetrievePortfolioComparison")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult RetrievePortfolioComparison([FromHeader] string jwt)
        {
            Object[] returnJson = CheetahHandler.GetTradeProposal(jwt, "1").Result;
            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            return Json(returnJson);
        }

        [HttpGet("AutoFill")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult GetMatches([FromQuery] string value)
        {
            try
            {
                return Json(AssetMatcher.GetAllAssets());
            }
            catch (Exception e)
            {
                return Json(HttpStatusCode.BadRequest);
            }
        }
        
        [HttpPost("ValidateAsset")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult ValidateAsset([FromBody] AssetValidationForm assetLookup)
        {
            return Json(AssetMatcher.GetValidatedAsset(assetLookup));
        }
        
        [HttpPost("PostImage")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult PostImage([FromBody] string imageStream)
        {
            Console.WriteLine(imageStream);
            var base64Data = Regex.Match(imageStream, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            var stream = new MemoryStream(binData);
            int[] imageDimensions = ImageConverter.GetDimensionsOfMemoryStream(stream);
            BoundingBox boxOne = new BoundingBox(5,5, 20, 20, "Wowser" );
            BoundingBox boxTwo = new BoundingBox(50,5, 20, 20, "Neat" );
            BoundingBox boxThree = new BoundingBox(12,100, 20, 20, "Lookie" );
            BoundingBox boxFour = new BoundingBox(50,100, 20, 20, "Cool" );
            BoundingBox[] arrayOfBoxes = new BoundingBox[4];
            arrayOfBoxes[0] = boxOne;
            arrayOfBoxes[1] = boxTwo;
            arrayOfBoxes[2] = boxThree;
            arrayOfBoxes[3] = boxFour;
            Console.WriteLine(imageDimensions[0] + " " + " " + imageDimensions[1]);
            return Json(arrayOfBoxes);
        }
        
        [HttpPost("PostImageWithBox")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult PostImageWithBox([FromBody] ImageWithBox imageWithBox)
        {
            Console.WriteLine(Json(imageWithBox));
            BoundingBox boxOne = new BoundingBox(5,5, 20, 20, "Wowser" );
            BoundingBox boxTwo = new BoundingBox(50,5, 20, 20, "Neat" );
            BoundingBox boxThree = new BoundingBox(12,100, 20, 20, "Lookie" );
            BoundingBox boxFour = new BoundingBox(50,100, 20, 20, "Cool" );
            BoundingBox[] arrayOfBoxes = new BoundingBox[4];
            arrayOfBoxes[0] = boxOne;
            arrayOfBoxes[1] = boxTwo;
            arrayOfBoxes[2] = boxThree;
            arrayOfBoxes[3] = boxFour;
            return Json(imageWithBox);
        }
    }
} 


