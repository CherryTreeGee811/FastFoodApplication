using System.ComponentModel.DataAnnotations;

namespace FastFoodAPI.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Job title is required.")]
        public int JobTitleId { get; set; }

        public JobTitle JobTitle { get; set; }

        public int? StationId { get; set; }

        public Station? Station { get; set; }

        public ICollection<TrainingAssignment> TrainingAssignments { get; set; } = new List<TrainingAssignment>();
    }
}
