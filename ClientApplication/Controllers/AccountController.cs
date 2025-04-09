using Microsoft.AspNetCore.Mvc;


public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Username and password are required.";
            return View();
        }

        // Replace this with your authentication logic
        if (username == "admin" && password == "password")
        {
            // Store the username in the session
            HttpContext.Session.SetString("LoggedInUser", username);

            // Redirect to the Employee details page
            return RedirectToAction("Details", "Employee", new { employeeID = 1 }); // Replace 1 with the actual employee ID
        }

        ViewBag.ErrorMessage = "Invalid username or password.";
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
