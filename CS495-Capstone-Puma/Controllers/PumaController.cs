using System.Collections.Generic;
using CS495_Capstone_Puma.DataStructure;
using CS495_Capstone_Puma.DataStructure.Account;
using CS495_Capstone_Puma.DataStructure.Asset;
using CS495_Capstone_Puma.DataStructure.Asset.AssetCategory;
using CS495_Capstone_Puma.DataStructure.NameAndAddress;
using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{    
    [Route("api/[controller]")]
    public class PumaController : Controller
    {
        
        //Receive POST request addressed to HostingAddress/api/Puma. Deserializes JSON in HttpRequest body into UIObject Data Structure.
        [HttpPost]
        public JsonResult ProcessPost([FromBody] UIObject uiObject)
        {
            //Instantiates class that communicates with Cheetah API
            CheetahHandler cheetah = new CheetahHandler();
            IdentityRecord identityRecord = uiObject.IdentityRecordObj;
            Account account = new Account(0, uiObject.IdentityRecordObj);
            List<Asset> assets = buildAssetList(uiObject);

            //Serializes cheetah response into data structure understood by the frontend & returns that object as JSON
            UIObject resp = cheetah.PostAndReceive(identityRecord, account, assets).Result;
            return Json(resp);
        }
        
        //Iterates through each list of the asset categories. Assembles them into a unified Asset object list
        private List<Asset> buildAssetList(UIObject uiObject)
        {
            List<Asset> assets = new List<Asset>();
            int i = 0;
            
            foreach (Bond bond in uiObject.Bonds)
            {
                i++;
                Asset asset = new Asset(i, "Bond", bond);
                assets.Add(asset);
            }
            
            foreach (Stock stock in uiObject.Stocks)
            {
                i++;
                Asset asset = new Asset(i, "Stock", stock);
                assets.Add(asset);
            }
            
            foreach (Loan loan in uiObject.Loans)
            {
                i++;
                Asset asset = new Asset(i, "Loan", loan);
                assets.Add(asset);
            }
            
            foreach (MutualFund mutualFund in uiObject.MutualFunds)
            {
                i++;
                Asset asset = new Asset(i, "MutualFund", mutualFund);
                assets.Add(asset);
            }
            
            foreach (Property property in uiObject.Properties)
            {
                i++;
                Asset asset = new Asset(i, "Property", property);
                assets.Add(asset);
            }
            
            foreach (CashEquivalent cashEquivalent in uiObject.CashEquivalents)
            {
                i++;
                Asset asset = new Asset(i, "CashEquivalent", cashEquivalent);
                assets.Add(asset);
            }

            return assets;
        }
    }
}


