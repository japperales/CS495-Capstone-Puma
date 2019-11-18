using Newtonsoft.Json;

namespace CS495_Capstone_Puma.Model
{
    public class Client
    {
        public string name { get; set; }
        public int age { get; set; }
        public double balance { get; set; }

        public Client() //Parameter-less constructor
        {
            name = "ja";
            age = 100;
            balance = 0;
        }

        [JsonConstructor]
        public Client(string name, int age, double balance) //Constructor to be used with JSON POST
        {
            this.name = name;
            this.age = age;
            this.balance = balance;
        }
    }
}