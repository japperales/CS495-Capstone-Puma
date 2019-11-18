using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS495_Capstone_Puma.Controllers
{    
    [Route("api/[controller]")]
    public class PumaController : Controller
    {
        [HttpPost]
        [Route("[action]")]
        public  JsonResult SendAndReceivePortfolio([FromBody] PersonalData person)
        {
            PersonalData newPersonalData = person;
            newPersonalData.honorific = "Ganja-San";
            return Json(newPersonalData);
        }
        public class PersonalData
        {
            public string firstName { get; set; }
            public string middleName{ get; set; }
            public string lastName { get; set; }
            public string honorific { get; set; }
            public string emailAddress { get; set; }
            
            public PersonalData(string firstName, string middleName, string lastName, string honorific, string emailAddress)
            {
                this.firstName = firstName;
                this.middleName = middleName;
                this.lastName = lastName;
                this.honorific = honorific;
                this.emailAddress = emailAddress;
            }
            
        }
    }
}


