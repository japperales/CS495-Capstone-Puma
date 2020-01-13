using Newtonsoft.Json;

namespace CS495_Capstone_Puma.DataStructure
{
    public class TokenResponse
    {
        [JsonProperty("Jwt")] public string Jwt { get; set; }
        
        [JsonProperty("ExpiresIn")] public int ExpiresIn { get; set; }
        
        [JsonProperty("IssuedDateTime")] public string IssuedDateTime { get; set; }
        
        [JsonProperty("ExpirationDateTime")] public string ExpirationDateTime { get; set; }
    }
}