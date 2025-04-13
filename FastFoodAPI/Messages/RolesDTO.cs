using System.Text.Json.Serialization;
using FastFoodAPI.Entities;

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

