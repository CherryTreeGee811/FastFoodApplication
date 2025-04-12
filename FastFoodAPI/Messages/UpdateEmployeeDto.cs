// File: FastFoodAPI/Models/PatchEmployeeDto.cs
using System.ComponentModel.DataAnnotations;

namespace FastFoodAPI.Models
{
    public class UpdateEmployeeDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EmailAddress { get; set; }

        public int? JobTitleId { get; set; }

        public int? StationId { get; set; }
    }
}
