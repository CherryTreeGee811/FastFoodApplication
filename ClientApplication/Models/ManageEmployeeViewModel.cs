using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class ManageEmployeeViewModel
    {

        public string? EmployeeID { get; set; }


        public TrainingModuleDTO SelectedTrainingModule { get; set; } = new TrainingModuleDTO();


        public StationDTO SelectedStation { get; set; } = new StationDTO();


        public ShiftsDTO SelectedShift { get; set; } = new ShiftsDTO();


        public RolesDTO SelectedRole { get; set; } = new RolesDTO();


        public ICollection<TrainingModuleDTO> TrainingModules { get; set; } = new List<TrainingModuleDTO>();


        public ICollection<StationDTO> Stations { get; set; } = new List<StationDTO>();


        public ICollection<ShiftsDTO> Shifts { get; set; } = new List<ShiftsDTO>();


        public ICollection<RolesDTO> Roles { get; set; } = new List<RolesDTO>();
    }
}
