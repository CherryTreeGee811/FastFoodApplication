using Microsoft.AspNetCore.Mvc;


namespace ClientApplication.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet("/employees/{employeeID}")]
        public IActionResult Index(int employeeID)
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
    }
}
