using Microsoft.AspNetCore.Mvc;


public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Email and password are required.";
            return View();
        }

        // Use hardcoded credentials for demonstration:
        if (email == "manager" && password == "manager123")
        {
            // For a manager:
            HttpContext.Session.SetString("Role", "Manager");
            HttpContext.Session.SetInt32("EmployeeID", 1); // example manager employeeID
            HttpContext.Session.SetString("LoggedInUser", email);

            // Redirect to the employee list page ("/employees")
            return RedirectToAction("List", "Employee");
        }
        else if (email == "worker" && password == "worker123")
        {
            // For a worker:
            HttpContext.Session.SetString("Role", "Worker");
            HttpContext.Session.SetInt32("EmployeeID", 2); // example worker employeeID
            HttpContext.Session.SetString("LoggedInUser", email);

            // Redirect to the specific employee details page ("/employees/{employeeID}")
            return RedirectToAction("Details", "Employee", new { employeeID = 2 });
        }

        ViewBag.ErrorMessage = "Invalid email or password.";
        return View();
    }


    [HttpPost]
    public IActionResult Logout()
    {
        // Clear the session
        HttpContext.Session.Clear();

        // Redirect to the Home page
        return RedirectToAction("Index", "Home");
    }
}
