using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class ManageEmployeeViewModel
    {

        public string? EmployeeID { get; set; }


        public TrainingModuleDTO SelectedTrainingModule { get; set; } = new();


        public StationDTO SelectedStation { get; set; } = new();


        public ShiftsDTO SelectedShift { get; set; } = new();


        public RolesDTO SelectedRole { get; set; } = new();


        public ICollection<TrainingModuleDTO> TrainingModules { get; set; } = [];


        public ICollection<StationDTO> Stations { get; set; } = [];


        public ICollection<ShiftsDTO> Shifts { get; set; } = [];


        public ICollection<RolesDTO> Roles { get; set; } = [];
    }
}
