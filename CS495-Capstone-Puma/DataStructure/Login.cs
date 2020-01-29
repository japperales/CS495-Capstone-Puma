using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class Login
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

        public Login()
        {
            Username = "";
            Password = "";
        }

        [JsonConstructor]
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}