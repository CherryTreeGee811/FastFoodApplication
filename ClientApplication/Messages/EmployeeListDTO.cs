using System.Text.Json.Serialization;


namespace ClientApplication.Messages
{
    public class EmployeeListDTO
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }


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
