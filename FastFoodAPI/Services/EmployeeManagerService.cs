using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using FastFoodAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Services
{
    public class EmployeeManagerService : IEmployeeManagerService
    {
        private readonly FastFoodDbContext _fastFoodDbContext;

        public EmployeeManagerService(FastFoodDbContext fastFoodDbContext)
        {
            _fastFoodDbContext = fastFoodDbContext;
        }

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>A list of all employees with their details.</returns>
        public async Task<IEnumerable<EmployeeListDTO>> GetAllEmployees()
        {
            return await _fastFoodDbContext.Employees
                .Select(e => new EmployeeListDTO
                {
                    EmployeeId = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    EmailAddress = e.Email,
                    JobTitle = e.JobTitle.Title,
                    StationName = e.Station != null ? e.Station.StationName : null
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The details of the specified employee, or null if not found.</returns>
        public async Task<EmployeeListDTO> GetEmployee(string id)
        {
            var employee = await _fastFoodDbContext.Employees
                .Include(e => e.JobTitle)
                .Include(e => e.Station)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return null;
            }

            return new EmployeeListDTO { 
                EmployeeId = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.Email,
                JobTitle = employee.JobTitle.Title,
                StationName = employee.Station != null ? employee.Station.StationName : null
            };
        }

        /// <summary>
        /// Retrieves a specific employee by email.
        /// </summary>
        /// <param name="email">The email of the employee to retrieve.</param>
        /// <returns>The details of the specified employee, or null if not found.</returns>
        public async Task<EmployeeListDTO> GetEmployeeByEmail(string email) {
            var employee = await _fastFoodDbContext.Employees
                .Include(e => e.JobTitle)
                .Include(e => e.Station)
                .FirstOrDefaultAsync(e => e.Email == email);

            if (employee == null) {
                return null;
            }

            return new EmployeeListDTO { 
                EmployeeId = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.Email,
                JobTitle = employee.JobTitle.Title,
                StationName = employee.Station != null ? employee.Station.StationName : null
            };
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="employeeDto">The employee details to create.</param>
        /// <returns>A tuple with the created employee and success status.</returns>
        public async Task<(Employee Employee, bool Success, string ErrorMessage)> CreateEmployee(EmployeeDto employeeDto)
        {
            // Check if email already exists
            if (await _fastFoodDbContext.Employees.AnyAsync(e => e.Email == employeeDto.EmailAddress))
            {
                return (null, false, "An employee with this email address already exists");
            }

            // Check if JobTitle exists
            if (!await _fastFoodDbContext.JobTitles.AnyAsync(jt => jt.JobTitleId == employeeDto.JobTitleId))
            {
                return (null, false, "Specified job title does not exist");
            }

            // Check if Station exists (if provided)
            if (employeeDto.StationId.HasValue &&
                !await _fastFoodDbContext.Stations.AnyAsync(s => s.StationId == employeeDto.StationId))
            {
                return (null, false, "Specified station does not exist");
            }

            // Map DTO to entity
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                JobTitleId = employeeDto.JobTitleId,
                StationId = employeeDto.StationId
            };

            await _fastFoodDbContext.Employees.AddAsync(employee);
            await _fastFoodDbContext.SaveChangesAsync();

            return (employee, true, string.Empty);
        }

        /// <summary>
        /// Updates an existing employee with any combination of fields.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="updateEmployeeDto">The updated employee details.</param>
        /// <returns>A tuple with the updated employee and success status.</returns>
        public async Task<(Employee Employee, bool Success, string ErrorMessage)> UpdateEmployee(string id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = await _fastFoodDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return (null, false, $"Employee with ID {id} not found");
            }

            // Check for unique email constraint if email is being changed
            if (updateEmployeeDto.EmailAddress != null &&
                existingEmployee.Email != updateEmployeeDto.EmailAddress &&
                await _fastFoodDbContext.Employees.AnyAsync(e => e.Email == updateEmployeeDto.EmailAddress))
            {
                return (null, false, "An employee with this email address already exists");
            }

            // Check if JobTitle exists if being updated
            if (updateEmployeeDto.JobTitleId.HasValue &&
                !await _fastFoodDbContext.JobTitles.AnyAsync(jt => jt.JobTitleId == updateEmployeeDto.JobTitleId))
            {
                return (null, false, "Specified job title does not exist");
            }

            // Check if Station exists if being updated
            if (updateEmployeeDto.StationId.HasValue &&
                updateEmployeeDto.StationId != null &&
                !await _fastFoodDbContext.Stations.AnyAsync(s => s.StationId == updateEmployeeDto.StationId))
            {
                return (null, false, "Specified station does not exist");
            }

            // Update only the provided employee properties
            if (updateEmployeeDto.FirstName != null)
                existingEmployee.FirstName = updateEmployeeDto.FirstName;

            if (updateEmployeeDto.LastName != null)
                existingEmployee.LastName = updateEmployeeDto.LastName;

            if (updateEmployeeDto.EmailAddress != null)
                existingEmployee.Email = updateEmployeeDto.EmailAddress;

            if (updateEmployeeDto.JobTitleId.HasValue)
                existingEmployee.JobTitleId = updateEmployeeDto.JobTitleId.Value;

            if (updateEmployeeDto.StationId.HasValue)
                existingEmployee.StationId = updateEmployeeDto.StationId;

            try
            {
                await _fastFoodDbContext.SaveChangesAsync();
                return (existingEmployee, true, string.Empty);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return (null, false, "Employee not found during update");
                }
                return (null, false, "A concurrency error occurred while updating the employee");
            }
        }

        /// <summary>
        /// Updates a single field of an existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="patchEmployeeDto">The field to update.</param>
        /// <returns>A tuple with the updated employee and success status.</returns>
        public async Task<(Employee Employee, bool Success, string ErrorMessage)> PatchEmployee(string id, UpdateEmployeeDto patchEmployeeDto)
        {
            var existingEmployee = await _fastFoodDbContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return (null, false, $"Employee with ID {id} not found");
            }

            // Count how many fields have values
            var fieldCount = 0;
            if (patchEmployeeDto.FirstName != null) fieldCount++;
            if (patchEmployeeDto.LastName != null) fieldCount++;
            if (patchEmployeeDto.EmailAddress != null) fieldCount++;
            if (patchEmployeeDto.JobTitleId.HasValue) fieldCount++;
            if (patchEmployeeDto.StationId.HasValue) fieldCount++;

            // Ensure only one field is being patched
            if (fieldCount != 1)
            {
                return (null, false, "Patch operation should update exactly one field");
            }

            // Check email uniqueness if email is being changed
            if (patchEmployeeDto.EmailAddress != null &&
                existingEmployee.Email != patchEmployeeDto.EmailAddress &&
                await _fastFoodDbContext.Employees.AnyAsync(e => e.Email == patchEmployeeDto.EmailAddress))
            {
                return (null, false, "An employee with this email address already exists");
            }

            // Check if JobTitle exists if being updated
            if (patchEmployeeDto.JobTitleId.HasValue &&
                !await _fastFoodDbContext.JobTitles.AnyAsync(jt => jt.JobTitleId == patchEmployeeDto.JobTitleId))
            {
                return (null, false, "Specified job title does not exist");
            }

            // Check if Station exists if being updated
            if (patchEmployeeDto.StationId.HasValue &&
                patchEmployeeDto.StationId != null &&
                !await _fastFoodDbContext.Stations.AnyAsync(s => s.StationId == patchEmployeeDto.StationId))
            {
                return (null, false, "Specified station does not exist");
            }

            // Apply the single field update
            if (patchEmployeeDto.FirstName != null)
                existingEmployee.FirstName = patchEmployeeDto.FirstName;
            else if (patchEmployeeDto.LastName != null)
                existingEmployee.LastName = patchEmployeeDto.LastName;
            else if (patchEmployeeDto.EmailAddress != null)
                existingEmployee.Email = patchEmployeeDto.EmailAddress;
            else if (patchEmployeeDto.JobTitleId.HasValue)
                existingEmployee.JobTitleId = patchEmployeeDto.JobTitleId.Value;
            else if (patchEmployeeDto.StationId.HasValue)
                existingEmployee.StationId = patchEmployeeDto.StationId;

            try
            {
                await _fastFoodDbContext.SaveChangesAsync();
                return (existingEmployee, true, string.Empty);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return (null, false, "Employee not found during update");
                }
                return (null, false, "A concurrency error occurred while updating the employee");
            }
        }

        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A tuple indicating success or failure with error message.</returns>
        public async Task<(bool Success, string ErrorMessage)> DeleteEmployee(string id)
        {
            var employee = await _fastFoodDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return (false, $"Employee with ID {id} not found");
            }

            _fastFoodDbContext.Employees.Remove(employee);
            await _fastFoodDbContext.SaveChangesAsync();

            return (true, string.Empty);
        }

        /// <summary>
        /// Checks if an employee exists by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to check.</param>
        /// <returns>True if the employee exists, otherwise false.</returns>
        public bool EmployeeExists(string id)
        {
            return _fastFoodDbContext.Employees.Any(e => e.Id == id);
        }
    }
}
