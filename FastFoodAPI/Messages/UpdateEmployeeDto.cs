// File: FastFoodAPI/Models/PatchEmployeeDto.cs
using System.Text.Json.Serialization;


namespace FastFoodAPI.Messages
{
    public class UpdateEmployeeDto
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }


        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }


        [JsonPropertyName("emailAddress")]
        public string? EmailAddress { get; set; }


        [JsonPropertyName("jobTitleId")]
        public int? JobTitleId { get; set; }


        [JsonPropertyName("stationId")]
        public int? StationId { get; set; }
    }
}
