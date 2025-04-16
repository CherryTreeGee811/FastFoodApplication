using System.Text.Json.Serialization;

namespace FastFoodAPI.Messages
{
    public class EmployeeListDTO
    {
        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; }


        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }


        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }


        [JsonPropertyName("emailAddress")]
        public string? EmailAddress { get; set; }


        [JsonPropertyName("jobTitle")]
        public string? JobTitle { get; set; }


        [JsonPropertyName("stationName")]
        public string? StationName { get; set; }
    }
}
