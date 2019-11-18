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
    public class ExampleClassController : Controller
    {
        [HttpGet("[action]")]
        public Person CoolGuyCreator()
        {
            Person person = new Person("JP", 22, "Professional Cool Guy");
            return person;
        }

        [HttpPost]
        [Route("[action]")]
        
        public  JsonResult ConvertLoser([FromBody] Person person)
        {
            person.job = "Professional Cool Guy";
           return Json(person);
        }

        public class Person
        {
            public string name { get; set; }
            public int age { get; set; }
            public string job { get; set; }
            
            public Person(string name, int age, string job)
            {
                this.name = name;
                this.age = age;
                this.job = job;
            }
            
        }
    }
    
    
}
