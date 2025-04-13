using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class ManageEmployeeViewModel
    {
        public TrainingModuleDTO SelectedTrainingModule { get; set; } = new TrainingModuleDTO();


        public StationDTO SelectedStation { get; set; } = new StationDTO();


        public ShiftsDTO SelectedShift { get; set; } = new ShiftsDTO();


        public RolesDTO SelectedRole { get; set; } = new RolesDTO();


        public ICollection<TrainingModuleDTO> TrainingModules { get; set; }


        public ICollection<StationDTO> Stations { get; set; }


        public ICollection<ShiftsDTO> Shifts { get; set; }


        public ICollection<RolesDTO> Roles { get; set; }
    }
}
