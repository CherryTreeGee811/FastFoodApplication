using System.ComponentModel.DataAnnotations;


namespace FastFoodAPI.Entities
{
    public class Station
    {
        public int StationId { get; set; }

        [Required(ErrorMessage = "Station name is required.")]
        public string StationName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Station description is required.")]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public ICollection<Employee> AssignedEmployees { get; set; } = [];
    }
}
