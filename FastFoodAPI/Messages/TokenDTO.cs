using System.Text.Json.Serialization;


namespace FastFoodAPI.Messages
{
    public class TokenDTO
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
