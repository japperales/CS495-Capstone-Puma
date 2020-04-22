using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class Login
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
        
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        public Login()
        {
            Username = "";
            Password = "";
            ApiKey = "";
        }

        [JsonConstructor]
        public Login(string username, string password, string apiKey)
        {
            Username = username;
            Password = password;
            ApiKey = apiKey;
        }
    }
}