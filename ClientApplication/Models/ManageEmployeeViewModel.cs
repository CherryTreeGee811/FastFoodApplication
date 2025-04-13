using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class ManageEmployeeViewModel
    {
        public ICollection<TrainingModuleDTO> TrainingModulesDTO { get; set; }


        public ICollection<StationDTO> StationDTO { get; set; }
    }
}
