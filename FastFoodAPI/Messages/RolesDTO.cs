using System.Text.Json.Serialization;


namespace FastFoodAPI.Messages
{
    public class RolesDTO
    {
        [JsonPropertyName("jobTitleId")]
        public int JobTitleId { get; set; }

        
        [JsonPropertyName("jobTitle")]
        public string? Title { get; set; } = string.Empty;
    }
}

