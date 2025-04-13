using FastFoodAPI.Messages;
using FastFoodAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace FastFoodAPI.Controllers {
    [ApiController()]
    [Route("/api")]
    public class AccountApiController : Controller {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApiController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service used for login and registration operations.</param>
        public AccountApiController(IAuthService authService) {
            _authservice = authService;
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
                return Ok(new { Token = await _authservice.CreateToken() });
            } else {
                return Unauthorized();
            }
        }

        /// <summary>
        /// Registers a new user with the provided details.
        /// </summary>
        /// <param name="registrationRequest">The registration request containing user details such as name, email, and password.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> indicating success or failure of the registration process.
        /// </returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(EmployeeRegistrationRequest registrationRequest) {
            var result = await _authservice.RegisterUser(registrationRequest);

            if (result.Success) {
                return Ok(new { message = "Registration successful" });
            }
            else {
                return BadRequest(new { errors = result.Errors });
            }
        }

        private IAuthService _authservice;
    }
}
