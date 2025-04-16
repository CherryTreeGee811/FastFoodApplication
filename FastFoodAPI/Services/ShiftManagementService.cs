using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Services
{
    public class ShiftManagementService : IShiftManagementService
    {
        private readonly FastFoodDbContext _dbContext;

        public ShiftManagementService(FastFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets all shift assignments for a specific employee.
        /// </summary>
        public async Task<IEnumerable<ShiftsDTO>> GetEmployeeShiftsAsync(string employeeId)
        {
            var shifts = await _dbContext.ShiftAssignments
                .Include(sa => sa.Shift)
                .Where(sa => sa.EmployeeId == employeeId)
                .Select(sa => new ShiftsDTO
                {
                    ShiftId = sa.ShiftId,
                    ShiftPosition = sa.Shift.ShiftPosition.ToString(),
                    EmployeeId = sa.EmployeeId,
                    ShiftDate = sa.ShiftDate
                })
                .OrderBy(sa => sa.ShiftDate)
                .ToListAsync();

            return shifts;
        }

        /// <summary>
        /// Assigns an employee to a shift on a specific date.
        /// </summary>
        public async Task<(ShiftsDTO Shift, bool Success, string ErrorMessage)> AssignShiftToEmployeeAsync(string employeeId, int shiftId, DateTime shiftDate)
        {
            // Check if the employee exists
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return (null, false, $"Employee with ID {employeeId} not found");
            }

            // Check if the shift exists
            var shift = await _dbContext.Shifts.FindAsync(shiftId);
            if (shift == null)
            {
                return (null, false, $"Shift with ID {shiftId} not found");
            }

            // Check if the employee is already assigned to this shift on this date
            var existingAssignment = await _dbContext.ShiftAssignments
                .FirstOrDefaultAsync(sa =>
                    sa.EmployeeId == employeeId &&
                    sa.ShiftId == shiftId &&
                    sa.ShiftDate.Date == shiftDate.Date);

            if (existingAssignment != null)
            {
                return (null, false, "Employee already assigned to this shift on this date");
            }

            // Create new shift assignment
            var shiftAssignment = new ShiftAssignment
            {
                EmployeeId = employeeId,
                ShiftId = shiftId,
                ShiftDate = shiftDate.Date
            };

            try
            {
                _dbContext.ShiftAssignments.Add(shiftAssignment);
                await _dbContext.SaveChangesAsync();

                // Create and return the DTO
                var shiftDTO = new ShiftsDTO
                {
                    ShiftId = shiftAssignment.ShiftId,
                    ShiftPosition = shift.ShiftPosition.ToString(),
                    EmployeeId = shiftAssignment.EmployeeId,
                    ShiftDate = shiftAssignment.ShiftDate
                };

                return (shiftDTO, true, string.Empty);
            }
            catch (Exception ex)
            {
                return (null, false, $"Error assigning shift: {ex.Message}");
            }
        }
    }
}
