using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class Login
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("x-api-key")]
        public string XApiKey { get; set; }

        public Login()
        {
            Username = "";
            Password = "";
            XApiKey = "";
        }

        [JsonConstructor]
        public Login(string username, string password, string xApiKey)
        {
            Username = username;
            Password = password;
            XApiKey = xApiKey;
        }
    }
}