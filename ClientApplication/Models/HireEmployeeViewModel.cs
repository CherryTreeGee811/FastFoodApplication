using ClientApplication.Messages;


namespace ClientApplication.Models
{
    public class HireEmployeeViewModel
    {
        public string Email { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public int SelectedRole { get; set; }


        public string Password { get; set; }


        public List<RolesDTO> Roles { get; set; } = new List<RolesDTO>();
    }
}
