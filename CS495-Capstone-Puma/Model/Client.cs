namespace CS495_Capstone_Puma.Model
{
    public class Client
    {
        public string name { get; set; }
        public int age { get; set; }
        public double balance { get; set; }

        public Client(string name, int age, double balance)
        {
            this.name = name;
            this.age = age;
            this.balance = balance;
        }
    }
}