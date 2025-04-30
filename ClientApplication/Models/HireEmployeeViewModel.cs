using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class HireEmployeeViewModel
    {
        public string Email { get; set; } = string.Empty;


        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;


        public int SelectedRole { get; set; }


        public string Password { get; set; } = string.Empty;


        public List<RolesDTO> Roles { get; set; } = [];
    }
}
