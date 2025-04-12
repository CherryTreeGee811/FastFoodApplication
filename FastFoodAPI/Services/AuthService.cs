using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FastFoodAPI.Services {

    /// <summary>
    /// Service for handling authentication and authorization operations.
    /// </summary>
    public class AuthService : IAuthService {

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager for managing employee accounts.</param>
        /// <param name="config">The application configuration for accessing settings.</param>
        /// <param name="fastFoodDbContext">The database context for accessing the database.</param>
        public AuthService(UserManager<Employee> userManager, IConfiguration config, FastFoodDbContext fastFoodDbContext) {
            _userManager = userManager;
            _config = config;
            _fastFoodDbContext = fastFoodDbContext;
        }

        /// <summary>
        /// Creates a JWT token for the authenticated user.
        /// </summary>
        /// <returns>A JWT token as a string.</returns>
        public async Task<string> CreateToken() {
            var signingCreds = GetSigningCreds();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCreds, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        /// <summary>
        /// Authenticates a user with the provided login credentials.
        /// </summary>
        /// <param name="loginRequest">The login request containing email and password.</param>
        /// <returns>True if authentication is successful; otherwise, false.</returns>
        public async Task<bool> LoginUser(EmployeeLoginRequest loginRequest) {
            // These two checks are redundant since the validation is already done in the controller, done to kill warnings
            if (string.IsNullOrEmpty(loginRequest.Password)) {
                throw new ArgumentException("Password cannot be null or empty.", nameof(loginRequest.Password));
            }

            if (string.IsNullOrEmpty(loginRequest.Email)) {
                throw new ArgumentException("Email cannot be null or empty.", nameof(loginRequest.Password));
            }

            _employee = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (_employee == null)
                return false;

            var result = await _userManager.CheckPasswordAsync(_employee, loginRequest.Password);
            return result;
        }

        /// <summary>
        /// Generates token options for the JWT.
        /// </summary>
        /// <param name="signingCreds">The signing credentials for the token.</param>
        /// <param name="claims">The claims to include in the token.</param>
        /// <returns>A <see cref="JwtSecurityToken"/> with the specified options.</returns>
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCreds, List<Claim> claims) {
            var jwtSettings = _config.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCreds
            );

            return tokenOptions;
        }

        /// <summary>
        /// Retrieves the signing credentials for the JWT.
        /// </summary>
        /// <returns>The signing credentials.</returns>
        private SigningCredentials GetSigningCreds() { 
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            
            if (string.IsNullOrEmpty(secretKey)) {
                throw new InvalidOperationException("SecretKey is not configured in JwtSettings.");
            }

            var key = Encoding.UTF8.GetBytes(secretKey);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Retrieves the claims for the authenticated user.
        /// </summary>
        /// <returns>A list of claims for the user.</returns>
        private async Task<List<Claim>> GetClaims() {
            if (_employee == null || string.IsNullOrEmpty(_employee.Email)) {
                throw new InvalidOperationException("Employee or Employee Email is null.");
            }

            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, _employee.Email)
                };

            var roles = await _userManager.GetRolesAsync(_employee);
            foreach (var role in roles) {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="registrationRequest">The registration request containing user details.</param>
        /// <returns>A tuple indicating success and any errors encountered during registration.</returns>
        public async Task<(bool Success, string[] Errors)> RegisterUser(EmployeeRegistrationRequest registrationRequest) {
            var employee = new Employee {
                UserName = registrationRequest.Email,
                Email = registrationRequest.Email,
                EmailAddress = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                JobTitleId = registrationRequest.JobTitleId,
                StationId = registrationRequest.StationId
            };

            // Create the user account
            var result = await _userManager.CreateAsync(employee, registrationRequest.Password);

            if (result.Succeeded) {
                // Assign role based on job title
                await AssignRoleBasedOnJobTitle(registrationRequest.JobTitleId, employee.Id);
                return (true, Array.Empty<string>());
            }

            return (false, result.Errors.Select(e => e.Description).ToArray());
        }

        /// <summary>
        /// Assigns a role to a user based on their job title.
        /// </summary>
        /// <param name="jobTitleId">The job title ID of the user.</param>
        /// <param name="userId">The ID of the user to assign the role to.</param>
        /// <returns>True if the role is successfully assigned; otherwise, false.</returns>
        public async Task<bool> AssignRoleBasedOnJobTitle(int jobTitleId, string userId) {
            // Find the employee
            var employee = await _userManager.FindByIdAsync(userId);
            if (employee == null)
                return false;

            // Map JobTitleId to specific roles
            // This is a simplified mapping - you might want to get this from a database
            string roleName = jobTitleId switch {
                1 => "Manager",
                2 => "Supervisor",
                3 => "Cashier",
                4 => "Cook",
                5 => "Cleaner",
                _ => "Employee" // Default role
            };

            // Check if role exists, create if not
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(_fastFoodDbContext),
                new List<IRoleValidator<IdentityRole>>(), // Provide an empty list for role validators
                new UpperInvariantLookupNormalizer(),    // Provide a default implementation for ILookupNormalizer
                new IdentityErrorDescriber(),            // Provide a default implementation for IdentityErrorDescriber
                null                                     // Logger can remain null if not needed
            );

            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));

            // Assign role to the user
            await _userManager.AddToRoleAsync(employee, roleName);
            return true;
        }

        private Employee? _employee;
        private FastFoodDbContext _fastFoodDbContext;
        private UserManager<Employee> _userManager;
        private IConfiguration _config;
    }
}
