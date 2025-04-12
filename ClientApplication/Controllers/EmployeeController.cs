using Microsoft.AspNetCore.Mvc;


namespace ClientApplication.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet("/employees/{employeeID}")]
        public IActionResult Details(int employeeID)
        {
            // Placeholder data for shifts
            ViewBag.Shifts = new List<(string Start, string End)>
                {
                    ("9:00 AM", "5:00 PM"),
                    ("10:00 AM", "6:00 PM"),
                    ("11:00 AM", "7:00 PM")
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
        public IActionResult List()
        {
            // Placeholder data for employees
            var employees = new List<(int EmployeeId, string FirstName, string LastName, string Role, string Position)>
            {
                (1, "John", "Doe", "Manager", "#1243"),
                (2, "Jane", "Smith", "Worker", "#4252"),
                (3, "Michael", "Brown", "Cook", "#5678"),
                (4, "Emily", "Davis", "Cashier", "#7890")
            };

            ViewBag.Employees = employees;

            return View();
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
    }
}
