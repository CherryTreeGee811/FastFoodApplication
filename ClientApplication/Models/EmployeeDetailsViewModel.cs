using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class EmployeeDetailsViewModel
    {
        public string? EmployeeId { get; set; }


        public ICollection<ShiftsDTO> Shifts { get; set; } = new List<ShiftsDTO>();


        public ICollection<TrainingModuleDTO> TrainingModules { get; set; } = new List<TrainingModuleDTO>();
    }
}
