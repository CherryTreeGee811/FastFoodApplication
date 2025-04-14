using ClientApplication.Messages;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;


public class AccountController : Controller
{
    private readonly HttpClient _client;
    private readonly string _baseURL;


    public AccountController(HttpClient client)
    {
        _client = client;
        _baseURL = "http://fastfoodapi:8000/api";
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.ErrorMessage = "Email and password are required.";
            return View();
        }


        try
        {
            var loginRequest = new EmployeeLoginRequest { Email = email, Password = password };
            var jsonContent = JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var loginResponse = await _client.PostAsync($"{_baseURL}/login", content);

            if (loginResponse.IsSuccessStatusCode)
            {
                // Deserialize the response content into a list of employees
                var tokenDto = await loginResponse.Content.ReadFromJsonAsync<TokenDTO>();


                if (string.IsNullOrEmpty(tokenDto.Token))
                {
                    ViewBag.ErrorMessage = "Invalid Username or Password.";
                    return View();
                }


                // Parse the token to extract claims
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(tokenDto.Token);

                // Extract the role claim
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                // Store the token and role in session
                HttpContext.Session.SetString("AuthToken", tokenDto.Token);


                if (string.IsNullOrEmpty(role))
                {
                    ViewBag.ErrorMessage = "Failed to retrieve role from token.";
                    return View();
                }

                var employeeResponse = await _client.GetAsync($"{_baseURL}/employees/email/{email}");

                employeeResponse.EnsureSuccessStatusCode();

                var employee = await employeeResponse.Content.ReadFromJsonAsync<EmployeeListDTO>();

                if(Equals(employee, null))
                {
                    ViewBag.ErrorMessage = "Employee Details could not be received.";
                    return View();
                }


                if (string.Equals(role, "Manager"))
                {
                    // For a manager:
                    HttpContext.Session.SetString("Role", "Manager");
                    HttpContext.Session.SetString("EmployeeID", employee.EmployeeId);
                    HttpContext.Session.SetString("LoggedInUser", email);

                    // Redirect to the employee list page ("/employees")
                    return RedirectToAction("List", "Employee");
                }
                else
                {
                    // For a worker:
                    HttpContext.Session.SetString("Role", "Worker");
                    HttpContext.Session.SetString("EmployeeID", employee.EmployeeId);
                    HttpContext.Session.SetString("LoggedInUser", email);

                    // Redirect to the specific employee details page ("/employees/{employeeID}")
                    return RedirectToAction("Details", "Employee", new { employeeID = employee.EmployeeId });
                }
            }
            else
            {
                // Handle unsuccessful login (e.g., log error, throw exception, etc.)
                ViewBag.ErrorMessage = $"Login failed: {loginResponse.ReasonPhrase}";
                return View();
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., network issues, serialization errors, etc.)
            ViewBag.ErrorMessage = $"An error occurred during login: {ex.Message}";
            return View();
        }
    }


    [HttpPost]
    public async Task <IActionResult> Logout()
    {
        // Create the HttpRequestMessage
        var logoutRequest = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/logout");

        var token = HttpContext.Session.GetString("AuthToken");

        // Add headers to the request
        logoutRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Send the request
        var logoutResponse = await _client.SendAsync(logoutRequest);
        logoutResponse.EnsureSuccessStatusCode();

        // Clear the session
        HttpContext.Session.Clear();

        // Redirect to the Home page
        return RedirectToAction("Index", "Home");
    }
}
