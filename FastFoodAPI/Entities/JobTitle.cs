using System.ComponentModel.DataAnnotations;


namespace FastFoodAPI.Entities
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }


        [Required(ErrorMessage = "Job title is required.")]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "Job description is required.")]
        public string Description { get; set; } = string.Empty;
    }
}
