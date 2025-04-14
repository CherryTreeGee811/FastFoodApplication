using Microsoft.AspNetCore.Mvc;
using ClientApplication.Messages;
using ClientApplication.Models;
using System.Text.Json;
using System.Text;
using FastFoodAPI.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Identity.Data;


namespace ClientApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _baseURL;


        public EmployeeController(HttpClient client)
        {
            _client = client;
            _baseURL = "http://fastfoodapi:8000/api";
        }


        [HttpGet("/employees/{employeeID}")]
        public async Task<IActionResult> Details(string employeeID)
        {
            // Call the API endpoint
            var trainingModuleResponse = await _client.GetAsync($"{_baseURL}/employees/{employeeID}/trainings");
            var shiftResponse = await _client.GetAsync($"{_baseURL}/employees/{employeeID}/shifts");

            // Ensure the response is successful
            trainingModuleResponse.EnsureSuccessStatusCode();
            shiftResponse.EnsureSuccessStatusCode();

            // Deserialize the response content into a list of training modules
            var trainingModules = await trainingModuleResponse.Content.ReadFromJsonAsync<List<TrainingModuleDTO>>();

            var shifts = await shiftResponse.Content.ReadFromJsonAsync<List<ShiftsDTO>>();

            var model = new EmployeeDetailsViewModel
            {
                EmployeeId = employeeID,
                Shifts = shifts,
                TrainingModules = trainingModules
            };

            return View(model);
        }


        [HttpPost("/employees/{employeeID}/complete-training/{courseID:int}")]
        public async Task<IActionResult> CompleteTraining([FromRoute] string employeeID, [FromRoute] int courseID)
        {
            try
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");

                // Call the API endpoint
                var response = await _client.PatchAsync($"{_baseURL}/employees/{employeeID}/trainings/{courseID}/complete", content);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Details", "Employee", new { employeeID });
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error fetching employees: {ex.Message}");
                return View("Error", new { message = "Unable to fetch employees at this time." });
            }
        }


        [HttpGet("/employees")]
        public async Task<IActionResult> List()
        {
            try
            {
                // Call the API endpoint
                var response = await _client.GetAsync($"{_baseURL}/employees");

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Deserialize the response content into a list of employees
                var employees =  await response.Content.ReadFromJsonAsync<List<EmployeeListDTO>>();


                return View(employees);
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error fetching employees: {ex.Message}");
                return View("Error", new { message = "Unable to fetch employees at this time." });
            }
        }


        [HttpPost("/employees/notify-schedule")]
        public IActionResult NotifySchedule()
        {
            // Placeholder logic for notifying staff
            Console.WriteLine("Staff notified of schedule.");

            return Json(new { success = true, message = "Staff notified of schedule." });
        }


        [HttpGet("/employees/hire")]
        public async Task<IActionResult> Hire()
        {
            // Call the API endpoint
            var roleResponse = await _client.GetAsync($"{_baseURL}/employees/roles");

            roleResponse.EnsureSuccessStatusCode();

            var roles = await roleResponse.Content.ReadFromJsonAsync<List<RolesDTO>>();

            var model = new HireEmployeeViewModel
            {
                Roles = roles
            };

            return View(model);
        }


        [HttpPost("/employees/hire")]
        public async Task<IActionResult> Hire(HireEmployeeViewModel hireEmployeeViewModel)
        {
            try
            {
                var registerRequest = new EmployeeRegistrationRequest
                {
                    FirstName = hireEmployeeViewModel.FirstName,
                    LastName = hireEmployeeViewModel.LastName,
                    Email = hireEmployeeViewModel.Email,
                    Password = hireEmployeeViewModel.Password,
                    JobTitleId = hireEmployeeViewModel.SelectedRole
                };

                var jsonContent = JsonSerializer.Serialize(registerRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var registerResponse = await _client.PostAsync($"{_baseURL}/register", content);

                registerResponse.EnsureSuccessStatusCode();

                // Redirect to the employee list after successful submission
                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network issues, serialization errors, etc.)
                throw new Exception("An error occurred during login: " + ex.Message);
            }
        }


        [HttpGet("/employees/{employeeID}/manage")]
        public async Task <IActionResult> Manage(string employeeID)
        {
            // Call the API endpoint
            var trainingResponse = await _client.GetAsync($"{_baseURL}/employees/trainingmodules");
            var stationResponse = await _client.GetAsync($"{_baseURL}/employees/workstations");
            var roleResponse = await _client.GetAsync($"{_baseURL}/employees/roles");
            var shiftResponse = await _client.GetAsync($"{_baseURL}/employees/shifts");

            // Ensure the response is successful
            trainingResponse.EnsureSuccessStatusCode();
            stationResponse.EnsureSuccessStatusCode();
            roleResponse.EnsureSuccessStatusCode();
            shiftResponse.EnsureSuccessStatusCode();

            // Deserialize the response content into a list of employees
            var trainingModules = await trainingResponse.Content.ReadFromJsonAsync<List<TrainingModuleDTO>>();
            var stations = await stationResponse.Content.ReadFromJsonAsync<List<StationDTO>>();
            var roles = await roleResponse.Content.ReadFromJsonAsync<List<RolesDTO>>();
            var shifts = await shiftResponse.Content.ReadFromJsonAsync<List<ShiftsDTO>>();

            var model = new ManageEmployeeViewModel
            {
                EmployeeID = employeeID,
                TrainingModules = trainingModules,
                Stations = stations,
                Roles = roles,
                Shifts = shifts
            };

            return View(model);
        }


        [HttpPost("/employees/{employeeID:int}/fire")]
        public async Task<IActionResult> Fire(int employeeID)
        {
            try
            {
                // Call the API endpoint
                var response = await _client.DeleteAsync($"{_baseURL}/{employeeID}");

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return View("Error", new { message = "Unable to fire this employee." });
            }
        }


        [HttpPost("/employees/{employeeID}/promote-demote")]
        public async Task<IActionResult> PromoteDemote([FromRoute] string employeeID, [FromForm] int roleID)
        {
            try
            {
                var employee = new UpdateEmployeeDto
                {
                    JobTitleId = roleID
                };

                var jsonContent = JsonSerializer.Serialize(employee);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Call the API endpoint
                var response = await _client.PatchAsync($"{_baseURL}/employees/{employeeID}", content);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return View("Error", new { message = "Unable to fire this employee." });
            }
        }


        [HttpPost("/employees/{employeeID}/relocate")]
        public async Task<IActionResult> Relocate([FromRoute] string employeeID, [FromForm] int stationID)
        {
            try
            {
                var employee = new UpdateEmployeeDto
                {
                    StationId = stationID
                };

                var jsonContent = JsonSerializer.Serialize(employee);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Call the API endpoint
                var response = await _client.PatchAsync($"{_baseURL}/employees/{employeeID}", content);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return View("Error", new { message = "Unable to fire this employee." });
            }
        }


        [HttpPost("/employees/{employeeID}/schedule")]
        public async Task<IActionResult> Schedule([FromRoute] string employeeID, [FromForm] int shiftID)
        {
            try
            {
                //var jsonContent = JsonSerializer.Serialize(employee);
                //var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Call the API endpoint
                //var response = await _client.PatchAsync($"{_baseURL}/employees/{employeeID}", content);

                // Ensure the response is successful
                //response.EnsureSuccessStatusCode();

                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return View("Error", new { message = "Unable to fire this employee." });
            }

            return RedirectToAction("Manage", new { employeeID });

            // Placeholder logic for scheduling an employee
            //Console.WriteLine($"Employee {employeeID} scheduled from {shiftsDTO.ShiftDate} to {shiftsDTO.ShiftId}");

            //return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/notify-schedule")]
        public IActionResult NotifySchedule(int employeeID)
        {
            // Placeholder logic for notifying the employee of their schedule
            Console.WriteLine($"Employee {employeeID} notified of schedule");

            return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/assign-training")]
        public async Task<IActionResult> AssignTraining([FromRoute] string employeeID, [FromForm] int trainingID)
        {
            try
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");

                var assignTrainingResponse = await _client.PostAsync($"{_baseURL}/employees/trainingmodules/{employeeID}/{trainingID}", content);

                // Ensure the response is successful
                assignTrainingResponse.EnsureSuccessStatusCode();
                
                //ToDo: Add indication of success
                return RedirectToAction("Manage", new { employeeID });
            }
            catch (Exception ex)
            {
                // ToDo: Add indication of failure
                return RedirectToAction("Manage", new { employeeID });
            }
        }
    }
}
