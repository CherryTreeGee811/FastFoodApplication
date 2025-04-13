using Microsoft.AspNetCore.Mvc;
using ClientApplication.Messages;
using ClientApplication.Models;


namespace ClientApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _baseURL;


        public EmployeeController(HttpClient client)
        {
            _client = client;
            _baseURL = "http://fastfoodapi:8000/api/employees";
        }


        [HttpGet("/employees/{employeeID}")]
        public IActionResult Details(int employeeID)
        {
            // Placeholder data for shifts
            ViewBag.Shifts = new List<(string Start, string End)>
                {
                    ("2025-04-12", "Morning"),
                    ("2025-04-13", "Afternoon"),
                    ("2025-04-15", "Night")
                };

            // Placeholder data for training
            ViewBag.Training = new List<(int CourseId, string CourseName)>
                {
                    (1, "Food Safety"),
                    (2, "Customer Service"),
                    (3, "Equipment Maintenance")
                };

            ViewBag.EmployeeID = employeeID;

            return View();
        }


        [HttpPost("/employees/complete-training")]
        public IActionResult CompleteTraining(int courseId)
        {
            // Simulate marking the course as complete
            // In the future, this will send a POST request to the API
            var completionTime = DateTime.UtcNow;

            // Log or process the completion (placeholder logic)
            Console.WriteLine($"Course {courseId} marked complete at {completionTime}");

            return Json(new { success = true, courseId, completionTime });
        }


        [HttpGet("/employees")]
        public async Task<IActionResult> List()
        {
            try
            {
                // Call the API endpoint
                var response = await _client.GetAsync(_baseURL);

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
        public IActionResult Hire()
        {
            return View();
        }


        [HttpPost("/employees/hire")]
        public IActionResult Hire(string firstName, string lastName, string role, string password)
        {
            // Placeholder logic for hiring a new employee
            Console.WriteLine($"New employee hired: {firstName} {lastName}, Role: {role}");

            // Redirect to the employee list after successful submission
            return RedirectToAction("List");
        }


        [HttpGet("/employees/{employeeID}/manage")]
        public async Task <IActionResult> Manage(int employeeID)
        {
            // Call the API endpoint
            var trainingResponse = await _client.GetAsync($"{_baseURL}/trainingmodules");
            var stationResponse = await _client.GetAsync($"{_baseURL}/workstations");
            var shiftsResponse = await _client.GetAsync($"{_baseURL}/workstations");

            // Ensure the response is successful
            trainingResponse.EnsureSuccessStatusCode();
            stationResponse.EnsureSuccessStatusCode();

            // Deserialize the response content into a list of employees
            var trainingModules = await trainingResponse.Content.ReadFromJsonAsync<List<TrainingModuleDTO>>();
            var stations = await stationResponse.Content.ReadFromJsonAsync<List<StationDTO>>();

            var model = new ManageEmployeeViewModel
            {
                TrainingModulesDTO = trainingModules,
                StationDTO = stations
            };


            ViewBag.Roles = new List<string> { "Manager", "Worker" };
            ViewBag.Positions = new List<string> { "#1243", "#4252", "#5678", "#7890" }; // Replace with API data later
            ViewBag.TrainingModules = new List<string> { "Food Safety", "Customer Service", "Equipment Maintenance" }; // Replace with API data later
            ViewBag.EmployeeID = employeeID;

            return View();
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
        public IActionResult PromoteDemote(int employeeID, string role)
        {
            // Placeholder logic for promoting/demoting an employee
            Console.WriteLine($"Employee {employeeID} role updated to {role}");

            return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/relocate")]
        public IActionResult Relocate(int employeeID, string position)
        {
            // Placeholder logic for relocating an employee
            Console.WriteLine($"Employee {employeeID} relocated to position {position}");

            return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/schedule")]
        public IActionResult Schedule(int employeeID, string startTime, string endTime)
        {
            // Placeholder logic for scheduling an employee
            Console.WriteLine($"Employee {employeeID} scheduled from {startTime} to {endTime}");

            return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/notify-schedule")]
        public IActionResult NotifySchedule(int employeeID)
        {
            // Placeholder logic for notifying the employee of their schedule
            Console.WriteLine($"Employee {employeeID} notified of schedule");

            return RedirectToAction("Manage", new { employeeID });
        }


        [HttpPost("/employees/{employeeID}/train")]
        public IActionResult Train(int employeeID, string trainingModule)
        {
            // Placeholder logic for assigning training to an employee
            Console.WriteLine($"Employee {employeeID} assigned to training: {trainingModule}");

            return RedirectToAction("Manage", new { employeeID });
        }

    }
}
