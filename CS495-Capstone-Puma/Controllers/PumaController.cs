using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using CS495_Capstone_Puma.AutoFill;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.AccountResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse;
using CS495_Capstone_Puma.DataStructure.JsonResponse.Asset;
using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using CS495_Capstone_Puma.DataStructure.BoundingBoxes;
using CS495_Capstone_Puma.DataStructure.Images;
using CS495_Capstone_Puma.OCR.DataStructure;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects;
using CS495_Capstone_Puma.OCR.DataStructure.ResponseObjects.BlockObjects.GeometryObjects;
using CS495_Capstone_Puma.OCR.TextAnalysis;
using Microsoft.AspNetCore.Http;


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
        public JsonResult PostImage([FromForm] IFormFile body)
        {
            byte[] imageBytes;
            string newFileName = new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds.ToString();
            newFileName = newFileName.Substring(0, newFileName.IndexOf('.')) + ".png";
            Image page = null;
            using (var memoryStream = new MemoryStream())
            {
                body.CopyTo(memoryStream);
                page = Image.FromStream(memoryStream);
                OCR.S3Upload.Upload.UploadDocument("pdfidentify", newFileName, memoryStream, RegionEndpoint.USEast2);
            }
            Thread.Sleep(5000);
            
            
            Console.Out.WriteLine(newFileName);
            TextractResponse response = Analyze.AnalyzeFile(newFileName).Result;
            

            //Dictionary of every block indexed by ID
            Dictionary<string, Block> allBlocks = new Dictionary<string, Block>();
            foreach (var block in response.Blocks)
            {
                allBlocks.Add(block.Id, block);
            }
            
            
            //for each table block, save all children
            //for each child, save all children
            int i = 1;
            List<Block> targetBlocks = new List<Block>(); 
            List<BoundingBoxIdentifier> boundingBoxes = new List<BoundingBoxIdentifier>();
            foreach (var table in response.FilterType("TABLE"))
            {
                Analyze.GetChildrenRecursive(allBlocks, table, targetBlocks);
                
                BoundingBox boundingBox = table.Geometry.BoundingBox;
                //Convert relative location to absolute pixels
                BoundingBoxIdentifier identifier = new BoundingBoxIdentifier((int) (page.Width * boundingBox.Left), 
                    (int) (page.Height * boundingBox.Top),
                    (int) (page.Width * boundingBox.Width),
                    (int) (page.Height * boundingBox.Height), 
                    i++.ToString(),
                    table.Id);
                
                boundingBoxes.Add(identifier);
            }
            
            PreservedData preservedData = new PreservedData(targetBlocks,boundingBoxes);
            

            return Json(preservedData);
        }
        
        [HttpPost("PostImageWithBox")]
        [EnableCors("AllowAnyOrigin")]
        public JsonResult PostImageWithBox([FromBody] PreservedData preservedData)
        {
            //Only the correct bounding box identifier will be returned
            string tableId = preservedData.BoundingBoxIdentifiers[0].Id;

            List<Block> allBlocks = preservedData.Blocks;
            preservedData.Blocks = preservedData.FilterToChildren(tableId);
            
            //Construct Table object
            Block[,] table = preservedData.ConstructTable(tableId);
            
            
            //Now, analyze the contexts of the cells to find the correct columns.
            int assetColumnIndex = preservedData.findAssetIndex(table, allBlocks);
            
            //GLHF
            return Json(null);
        }
    }
} 


