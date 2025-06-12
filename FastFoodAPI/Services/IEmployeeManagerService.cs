using FastFoodAPI.Entities;
using FastFoodAPI.Messages;


namespace FastFoodAPI.Services
{
    public interface IEmployeeManagerService
    {
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>A list of all employees with their details.</returns>
        Task<IEnumerable<EmployeeListDTO>> GetAllEmployees();


        /// <summary>
        /// Retrieves a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The details of the specified employee packaged in a EmployeeListDTO, or null if not found.</returns>
        Task<EmployeeListDTO> GetEmployee(string id);


        /// <summary>
        /// Retrieves a specific employee by email.
        /// </summary>
        /// <param name="email">The email of the employee to retrieve.</param>
        /// <returns>The details of the specified employee packaged in a EmployeeListDTO, or null if not found.</returns>
        Task<EmployeeListDTO> GetEmployeeByEmail(string email);


        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employeeDto">The employee details to create.</param>
        /// <returns>The created employee.</returns>
        Task<(Employee Employee, bool Success, string ErrorMessage)> CreateEmployee(EmployeeDto employeeDto);


        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="updateEmployeeDto">The updated employee details.</param>
        /// <returns>A tuple with the updated employee and success status.</returns>
        Task<(Employee Employee, bool Success, string ErrorMessage)> UpdateEmployee(string id, UpdateEmployeeDto updateEmployeeDto);


        // Add to IEmployeeManagerService
        /// <summary>
        /// Updates a single field of an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="patchEmployeeDto">The field to update.</param>
        /// <returns>A tuple with the updated employee and success status.</returns>
        Task<(Employee Employee, bool Success, string ErrorMessage)> PatchEmployee(string id, UpdateEmployeeDto patchEmployeeDto);


        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A tuple indicating success or failure with error message.</returns>
        Task<(bool Success, string ErrorMessage)> DeleteEmployee(string id);


        /// <summary>
        /// Checks if an employee exists by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to check.</param>
        /// <returns>True if the employee exists, otherwise false.</returns>
        bool EmployeeExists(string id);
    }
}
