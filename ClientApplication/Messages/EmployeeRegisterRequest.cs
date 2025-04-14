using System.Text.Json.Serialization;


namespace ClientApplication.Messages {
    public class EmployeeRegistrationRequest {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;


        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;


        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;


        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;


        [JsonPropertyName("jobTitleId")]
        public int JobTitleId { get; set; }


        [JsonPropertyName("stationId")]
        public int? StationId { get; set; }
    }
}