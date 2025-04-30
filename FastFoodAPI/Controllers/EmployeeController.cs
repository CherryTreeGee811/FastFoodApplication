using FastFoodAPI.Messages;
using FastFoodAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FastFoodAPI.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing employees.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="EmployeeController"/> class.
    /// </remarks>
    /// <param name="employeeManagerService">The service for managing employees.</param>
    [ApiController]
    [Route("/api")]
    public class EmployeeController(IEmployeeManagerService employeeManagerService) : ControllerBase
    {
        private readonly IEmployeeManagerService _employeeManagerService = employeeManagerService;


        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>A list of all employees with their details.</returns>
        [HttpGet("employees")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeManagerService.GetAllEmployees();
            return Ok(employees);
        }


        /// <summary>
        /// Retrieves a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The details of the specified employee.</returns>
        [HttpGet("employees/{id}")]
        [Authorize(Roles = ("Manager,Cashier,Cook,Cleaner,Employee"))]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await _employeeManagerService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            return Ok(employee);
        }


        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="updateEmployeeDto">The updated employee details.</param>
        /// <returns>The updated employee if successful.</returns>
        [HttpPut("employees/{id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> UpdateEmployee(string id, UpdateEmployeeDto updateEmployeeDto)
        {
            var (employee, success, errorMessage) = await _employeeManagerService.UpdateEmployee(id, updateEmployeeDto);

            if (!success)
            {
                if (errorMessage.Contains("not found"))
                {
                    return NotFound(errorMessage);
                }
                return BadRequest(errorMessage);
            }

            return Ok(employee);
        }


        /// <summary>
        /// Updates a single field of an employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="patchEmployeeDto">The field to update.</param>
        /// <returns>The updated employee if successful.</returns>
        [HttpPatch("employees/{id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> PatchEmployee(string id, UpdateEmployeeDto patchEmployeeDto)
        {
            var (employee, success, errorMessage) = await _employeeManagerService.PatchEmployee(id, patchEmployeeDto);

            if (!success)
            {
                if (errorMessage.Contains("not found"))
                {
                    return NotFound(errorMessage);
                }
                return BadRequest(errorMessage);
            }

            return Ok(employee);
        }


        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A success message if the deletion is successful.</returns>
        [HttpDelete("employees/{id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var (success, errorMessage) = await _employeeManagerService.DeleteEmployee(id);

            if (!success)
            {
                return NotFound(errorMessage);
            }

            return Ok(new { message = $"Employee with ID {id} has been successfully deleted" });
        }
        
        /// <summary>
        /// This method allows retrieval of an employee by their email.
        /// </summary>
        [HttpGet("employees/email/{email}")]
        [Authorize(Roles = ("Manager,Cashier,Cook,Cleaner,Employee"))]
        public async Task<IActionResult> GetEmployeeByEmail(string email)
        {
            var employee = await _employeeManagerService.GetEmployeeByEmail(email);

            if (employee == null)
            {
                return NotFound($"Employee with Email {email} not found");
            }

            return Ok(employee);
        }
    }
}
