using FastFoodAPI.Messages;


namespace FastFoodAPI.Services
{
    public interface IShiftManagementService
    {
        /// <summary>
        /// Gets all shift assignments for a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A list of shift assignments for the employee.</returns>
        Task<IEnumerable<ShiftsDTO>> GetEmployeeShiftsAsync(string employeeId);


        /// <summary>
        /// Assigns an employee to a shift on a specific date.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="shiftId">The ID of the shift.</param>
        /// <param name="shiftDate">The date of the shift.</param>
        /// <returns>A tuple with the created shift assignment DTO, success status, and error message if any.</returns>
        Task<(ShiftsDTO Shift, bool Success, string ErrorMessage)> AssignShiftToEmployeeAsync(string employeeId, int shiftId, DateTime shiftDate);
    }
}
