using System;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure.IdentityRecord;
using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        [HttpPost]
        public JsonResult ConvertData([FromBody] IdentityRecord identityRecord)
        {
            CheetahHandler cheetah = new CheetahHandler();
            Console.Out.WriteLine(identityRecord);
            return Json(cheetah.GetIdentityRecord(identityRecord));
        }
    }
}