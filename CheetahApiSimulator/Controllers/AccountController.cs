using System.IO;
using CS495_Capstone_Puma.DataStructure.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CheetahApiSimulator.Controllers
{
    [ApiController]
    [Route("api/v6/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public Account Get()
        {
            return buildAccount(2);
        }
        
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return buildAccount(id);
        }

        [HttpPost]
        public Account Post([FromBody] Account account)
        {
            using (StreamWriter file = System.IO.File.CreateText(@"Resources\Account\"+account.AccountId+".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, account);
            }
            return account;
        }

        public Account buildAccount(int id)
        {
            using StreamReader file = System.IO.File.OpenText(@"Resources\Account\"+id+".json");
            JsonSerializer serializer = new JsonSerializer();
            Account account = (Account) serializer.Deserialize(file, typeof(Account));

            return account;
        }
    }
}