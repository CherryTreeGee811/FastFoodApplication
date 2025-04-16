using FastFoodAPI.Messages;
using FastFoodAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FastFoodAPI.Controllers {
    [ApiController()]
    [Route("/api")]
    public class AccountApiController : Controller {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApiController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service used for login and registration operations.</param>
        public AccountApiController(IAuthService authService, IEmployeeManagerService employeeManagerService) {
            _authservice = authService;
            _employeeManagerService = employeeManagerService;
        }

        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="loginRequest">The login request containing the user's email and password.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing a token if login is successful, or an Unauthorized response if it fails.
        /// </returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(EmployeeLoginRequest loginRequest) {
            bool isSuccessful = await _authservice.LoginUser(loginRequest);

            if (isSuccessful) {
                var token = new TokenDTO { Token = await _authservice.CreateToken() };
                return Ok(token);
            } else {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Logs out a user by invalidating their JWT token.
        /// </summary>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating success of the logout operation.
        /// </returns>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser() {
            // Get the token from the Authorization header
            string authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader != null && authHeader.StartsWith("Bearer ")) {
                string token = authHeader.Substring("Bearer ".Length).Trim();
                await _authservice.InvalidateToken(token);
                return Ok(new { message = "Logout successful" });
            }

            return BadRequest(new { message = "No valid token provided" });
        }

        /// <summary>
        /// Registers a new user with the provided details.
        /// </summary>
        /// <param name="registrationRequest">The registration request containing user details such as name, email, and password.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating success or failure of the registration process.
        /// </returns>
        [HttpPost("register")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterUser(EmployeeRegistrationRequest registrationRequest) {
            var result = await _authservice.RegisterUser(registrationRequest);

            if (result.Success) {
                var newEmployee = await _employeeManagerService.GetEmployeeByEmail(registrationRequest.Email);
                var locationUri = Url.Action("GetUserByEmail", "AccountApi", new { email = registrationRequest.Email }, Request.Scheme);
                return Created(locationUri, new EmployeeListDTO { 
                    EmployeeId = newEmployee.EmployeeId,
                    FirstName = newEmployee.FirstName,
                    LastName = newEmployee.LastName,
                    EmailAddress = newEmployee.EmailAddress,
                    JobTitle = newEmployee.JobTitle,
                    StationName = newEmployee.StationName
                });
            } 
            
            if (result.Errors.Any(error => error.Contains("taken", StringComparison.OrdinalIgnoreCase))) {
                return Conflict(new { errors = result.Errors });
            }

            return BadRequest(new { errors = result.Errors });
        }

        private IAuthService _authservice;
        private IEmployeeManagerService _employeeManagerService;
    }
}
