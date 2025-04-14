using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FastFoodAPI.Messages {
    public class EmployeeRegistrationRequest {
        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("lastName")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("jobTitleId")]
        [Required(ErrorMessage = "Job title ID is required")]
        public int JobTitleId { get; set; }

        [JsonPropertyName("stationId")]
        public int? StationId { get; set; }
    }
}