using System.ComponentModel.DataAnnotations;

namespace FastFoodAPI.Messages
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; } = string.Empty;


        [Required(ErrorMessage = "Job title ID is required.")]
        public int JobTitleId { get; set; }


        public int? StationId { get; set; }
    }
}
