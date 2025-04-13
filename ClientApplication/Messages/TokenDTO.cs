using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class TokenDTO
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
