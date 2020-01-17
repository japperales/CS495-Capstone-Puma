using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class Login
    {
        [JsonProperty("x-api-key")]
        public string XApiKey { get; set; }
        
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }

        public Login()
        {
            XApiKey = "";
            Username = "";
            Password = "";
        }

        [JsonConstructor]
        public Login(string xApiKey, string username, string password)
        {
            XApiKey = xApiKey;
            Username = username;
            Password = password;
        }
    }
}