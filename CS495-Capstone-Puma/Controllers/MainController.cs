using CS495_Capstone_Puma.Model;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        [HttpPost]
        [Route("[action]")]
        public JsonResult ConvertData([FromBody] Client client)
        {
            CheetahHandler cheetah = new CheetahHandler();
            Client converted = cheetah.convert(client);
            return Json(converted);
        }
    }
}