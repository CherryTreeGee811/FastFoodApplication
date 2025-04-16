using Microsoft.AspNetCore.Mvc;
using ClientApplication.Messages;
using ClientApplication.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;


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
            var trainingModuleRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/{employeeID}/trainings");
            var shiftRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/{employeeID}/shifts");

            var token = HttpContext.Session.GetString("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                trainingModuleRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                shiftRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Call the API endpoint
            var trainingModuleResponse = await _client.SendAsync(trainingModuleRequest);
            var shiftResponse = await _client.SendAsync(shiftRequest);

            // Ensure the response is successful
            trainingModuleResponse.EnsureSuccessStatusCode();
            shiftResponse.EnsureSuccessStatusCode();

            // Deserialize the response content into a list of training modules
            var trainingModules = await trainingModuleResponse.Content.ReadFromJsonAsync<List<TrainingModuleDTO>>() ?? new List<TrainingModuleDTO>();
            var shifts = await shiftResponse.Content.ReadFromJsonAsync<List<ShiftsDTO>>() ?? new List<ShiftsDTO>();

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
                var request = new HttpRequestMessage(HttpMethod.Patch, $"{_baseURL}/employees/{employeeID}/trainings");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var content = new StringContent("", Encoding.UTF8, "application/json");

                request.Content = content;

                // Call the API endpoint
                var response = await _client.SendAsync(request);

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
                var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                // Call the API endpoint
                var response = await _client.SendAsync(request);

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


        [HttpPost("/employees/{employeeID}/notify-schedule")]
        public async Task<IActionResult> NotifyScheduleByEmployeeID([FromRoute] string employeeID)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/employees/shifts/send-email/{employeeID}");

                var token = HttpContext.Session.GetString("AuthToken");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                // Call the API endpoint
                var response = await _client.SendAsync(request);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Details", "Employee", new { employeeID });
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error fetching employees: {ex.Message}");

                return RedirectToAction("Details", "Employee", new { employeeID });
            }
        }


        [HttpPost("/employees/notify-schedule")]
        public async Task<IActionResult> NotifyScheduleForAllEmployees()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/employees/shifts/send-email");

                var token = HttpContext.Session.GetString("AuthToken");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                // Call the API endpoint
                var response = await _client.SendAsync(request);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error fetching employees: {ex.Message}");
                return RedirectToAction("List", "Employee");
            }
        }


        [HttpGet("/employees/hire")]
        public async Task<IActionResult> Hire()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/roles");

            var token = HttpContext.Session.GetString("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Call the API endpoint
            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var roles = await response.Content.ReadFromJsonAsync<List<RolesDTO>>() ?? new List<RolesDTO>();

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

                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/register");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                request.Content = content;

                var registerResponse = await _client.SendAsync(request);

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
            var trainingRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/trainingmodules");
            var stationRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/workstations");
            var roleRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/roles");
            var shiftRequest = new HttpRequestMessage(HttpMethod.Get, $"{_baseURL}/employees/shifts");

            var token = HttpContext.Session.GetString("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                trainingRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                stationRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                roleRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                shiftRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Call the API endpoint
            var trainingResponse = await _client.SendAsync(trainingRequest);
            var stationResponse = await _client.SendAsync(stationRequest);
            var roleResponse = await _client.SendAsync(roleRequest);
            var shiftResponse = await _client.SendAsync(shiftRequest);

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
                TrainingModules = trainingModules ?? new List<TrainingModuleDTO>(),
                Stations = stations ?? new List<StationDTO>(),
                Roles = roles ?? new List<RolesDTO>(),
                Shifts = shifts ?? new List<ShiftsDTO>()
            };

            return View(model);
        }


        [HttpPost("/employees/{employeeID:int}/fire")]
        public async Task<IActionResult> Fire(int employeeID)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseURL}/{employeeID}");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                // Call the API endpoint
                var response = await _client.SendAsync(request);

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

                var request = new HttpRequestMessage(HttpMethod.Patch, $"{_baseURL}/employees/{employeeID}");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                request.Content = content;

                // Call the API endpoint
                var response = await _client.SendAsync(request);

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

                var request = new HttpRequestMessage(HttpMethod.Patch, $"{_baseURL}/employees/{employeeID}");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                request.Content = content;

                // Call the API endpoint
                var response = await _client.SendAsync(request);

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
        public async Task<IActionResult> Schedule([FromRoute] string employeeID, [FromForm] int shiftID, string shiftDate)
        {
            try
            {
                var date = DateTime.Parse(shiftDate);

                var assignShiftRequest = new AssignShiftRequest
                {
                    ShiftId = shiftID,
                    ShiftDate = date
                };

                var jsonContent = JsonSerializer.Serialize(assignShiftRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/employees/{employeeID}/shifts");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                request.Content = content;

                // Call the API endpoint
                var response = await _client.SendAsync(request);

                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // ToDo: Add indication of success
                return RedirectToAction("List", "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // ToDo: Add better indication of failure
                return RedirectToAction("Manage", new { employeeID });
            }
        }


        [HttpPost("/employees/{employeeID}/assign-training")]
        public async Task<IActionResult> AssignTraining([FromRoute] string employeeID, [FromForm] int trainingID)
        {
            try
            {
                var content = new StringContent("", Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/employees/trainingmodules/{employeeID}/{trainingID}");

                var token = HttpContext.Session.GetString("AuthToken");
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                request.Content = content;

                var assignTrainingResponse = await _client.SendAsync(request);

                // Ensure the response is successful
                assignTrainingResponse.EnsureSuccessStatusCode();
                
                //ToDo: Add indication of success
                return RedirectToAction("Manage", new { employeeID });
            }
            catch (Exception ex)
            {
                // Log the error and return an error view or message
                Console.WriteLine($"Error: {ex.Message}");
                return View("Error", new { message = "An error occurred while processing your request." });
            }

        }
    }
}
