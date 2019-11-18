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
        [HttpPost]
        public JsonResult ProcessPost([FromBody] UIObject uiObject)
        {
            
            CheetahHandler cheetah = new CheetahHandler();
            IdentityRecord identityRecord = uiObject.IdentityRecordObj;
            Account account = new Account(0, uiObject.IdentityRecordObj);
            List<Asset> assets = buildAssetList(uiObject);

            UIObject resp = cheetah.postAndReceive(identityRecord, account, assets).Result;

            return Json(resp);
        }
        
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


