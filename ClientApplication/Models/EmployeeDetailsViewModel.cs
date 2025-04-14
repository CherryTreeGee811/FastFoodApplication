using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class EmployeeDetailsViewModel
    {
        public string EmployeeId { get; set; }


        public ICollection<ShiftsDTO> Shifts { get; set; }


        public ICollection<TrainingModuleDTO> TrainingModules { get; set; }
    }
}
