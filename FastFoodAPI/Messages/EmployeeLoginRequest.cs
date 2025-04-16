using System.ComponentModel.DataAnnotations;

namespace FastFoodAPI.Messages {
    public class EmployeeLoginRequest {
        [Required(ErrorMessage = "An email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string? Password { get; set; }
    }
}
