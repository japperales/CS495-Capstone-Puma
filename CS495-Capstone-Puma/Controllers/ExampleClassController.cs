using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("[action]")]
        public Person ConvertLoser()
        {
            
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Job { get; set; }
            
            public Person(string name, int age, string job)
            {
                this.Name = name;
                this.Age = age;
                this.Job = job;
            }
            
        }
    }
    
    
}
