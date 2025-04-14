using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using FastFoodAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ShiftManagementController : ControllerBase
    {
        private readonly ILogger<ShiftManagementController> _logger;
        private readonly FastFoodDbContext _fastFoodDbContext;
        private readonly IShiftManagementService _shiftManagementService;

        public ShiftManagementController(
            ILogger<ShiftManagementController> logger,
            FastFoodDbContext fastFoodDbContext,
            IShiftManagementService shiftManagementService)
        {
            _logger = logger;
            _fastFoodDbContext = fastFoodDbContext;
            _shiftManagementService = shiftManagementService;
        }

        /// <summary>
        /// This method retrieves all available roles to the client.
        /// </summary>
        [HttpGet("employees/roles")]
        public IActionResult GetRoles()
        {
            var roles = _fastFoodDbContext.JobTitles.Select(role => new RolesDTO
            {
                JobTitleId = role.JobTitleId,
                Title = role.Title
            }).ToList();
            return Ok(roles);
        }

        /// <summary>
        /// This method retrieves all available shifts to the client.
        /// </summary>
        [HttpGet("employees/shifts")]
        public IActionResult GetShifts()
        {
            var shifts = _fastFoodDbContext.Shifts.Select(shift => new ShiftsDTO
            {
                ShiftId = shift.ShiftId,
                ShiftPosition = shift.ShiftPosition.ToString()
            }).ToList();
            return Ok(shifts);
        }

        /// <summary>
        /// Gets all shifts for a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A list of shift assignments for the employee.</returns>
        [HttpGet("employees/{employeeId}/shifts")]
        public async Task<IActionResult> GetEmployeeShifts(string employeeId)
        {
            try
            {
                var shifts = await _shiftManagementService.GetEmployeeShiftsAsync(employeeId);
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving shifts for employee {employeeId}");
                return StatusCode(500, "An error occurred while retrieving employee shifts.");
            }
        }

        /// <summary>
        /// Assigns an employee to a shift on a specific date.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="shiftId">The ID of the shift.</param>
        /// <param name="shiftDate">The date of the shift.</param>
        [HttpPost("employees/{employeeId}/shifts")]
        public async Task<IActionResult> AssignShift(string employeeId, [FromBody] AssignShiftRequest request)
        {
            if (request == null || request.ShiftId <= 0)
            {
                return BadRequest("Invalid shift data");
            }

            try
            {
                var (shift, success, errorMessage) = await _shiftManagementService.AssignShiftToEmployeeAsync(
                    employeeId,
                    request.ShiftId,
                    request.ShiftDate);

                if (!success)
                {
                    if (errorMessage.Contains("not found"))
                    {
                        return NotFound(errorMessage);
                    }
                    return BadRequest(errorMessage);
                }

                return Ok(shift);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error assigning shift for employee {employeeId}");
                return StatusCode(500, "An error occurred while assigning the shift.");
            }
        }

        /// <summary>
        /// Updates an existing shift assignment for an employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="shiftId">The current ID of the shift to update.</param>
        /// <param name="request">The updated shift details.</param>
        /// <returns>The updated shift assignment if successful.</returns>
        [HttpPut("employees/shifts/{employeeId}/{shiftId}")]
        public async Task<IActionResult> UpdateShiftForEmployee(string employeeId, int shiftId, [FromBody] UpdateShiftRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid shift data");
            }

            try
            {
                // Find the shift assignment
                var shiftAssignment = await _fastFoodDbContext.ShiftAssignments
                    .FirstOrDefaultAsync(sa =>
                        sa.EmployeeId == employeeId &&
                        sa.ShiftId == shiftId &&
                        sa.ShiftDate.Date == request.OriginalShiftDate.Date);

                if (shiftAssignment == null)
                {
                    return NotFound($"Shift assignment not found for employee {employeeId} on {request.OriginalShiftDate.Date:d} with shift ID {shiftId}");
                }

                // Determine if we need to update the shift ID
                int targetShiftId = request.NewShiftId != 0 && request.NewShiftId != shiftId
                    ? request.NewShiftId
                    : shiftId;

                // If changing shift ID, validate that the new shift exists
                if (targetShiftId != shiftId)
                {
                    var newShift = await _fastFoodDbContext.Shifts.FindAsync(targetShiftId);
                    if (newShift == null)
                    {
                        return BadRequest($"Shift with ID {targetShiftId} not found");
                    }
                }

                // Determine the target date
                DateTime targetDate = request.NewShiftDate.HasValue
                    ? request.NewShiftDate.Value.Date
                    : request.OriginalShiftDate.Date;

                // If no actual changes are being made, return a BadRequest
                if (targetShiftId == shiftId && targetDate == request.OriginalShiftDate.Date)
                {
                    return BadRequest("No changes requested for the shift assignment");
                }

                // Check for existing assignment at the new shift/date combination
                var existingAssignment = await _fastFoodDbContext.ShiftAssignments
                    .AnyAsync(sa =>
                        sa.EmployeeId == employeeId &&
                        sa.ShiftId == targetShiftId &&
                        sa.ShiftDate.Date == targetDate &&
                        (sa.ShiftId != shiftId || sa.ShiftDate.Date != request.OriginalShiftDate.Date)); // Exclude the current assignment

                if (existingAssignment)
                {
                    return BadRequest("Employee is already assigned to this shift on the requested date");
                }

                // Create new shift assignment
                var newShiftAssignment = new ShiftAssignment
                {
                    EmployeeId = employeeId,
                    ShiftId = targetShiftId,
                    ShiftDate = targetDate
                };

                // Remove old assignment and add new one
                _fastFoodDbContext.ShiftAssignments.Remove(shiftAssignment);
                _fastFoodDbContext.ShiftAssignments.Add(newShiftAssignment);
                await _fastFoodDbContext.SaveChangesAsync();

                // Get the shift details for the response
                var shift = await _fastFoodDbContext.Shifts.FindAsync(targetShiftId);
                var shiftDTO = new ShiftsDTO
                {
                    ShiftId = newShiftAssignment.ShiftId,
                    ShiftPosition = shift.ShiftPosition.ToString(),
                    EmployeeId = newShiftAssignment.EmployeeId,
                    ShiftDate = newShiftAssignment.ShiftDate
                };

                return Ok(shiftDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating shift for employee {employeeId}");
                return StatusCode(500, "An error occurred while updating the shift assignment.");
            }
        }

        /// <summary>
        /// This method allows us to assign a training module to an employee.
        /// </summary>
        [HttpPost("employees/trainingmodules/{employeeId}/{trainingId:int}")]
        public IActionResult AssignTrainingModuleToEmployee(string employeeId, int trainingId)
        {
            /*
             * First we need to check if the employee is already assigned to the training module.
             * If it is, the request is halted.
             */
            var trainingAssignmentCheck = _fastFoodDbContext.TrainingAssignments
                .FirstOrDefault(t => t.TrainingId == trainingId && t.EmployeeId == employeeId);

            if (trainingAssignmentCheck != null)
            {
                return Conflict(new {Message = "Employee already assigned to this training module."});
            }

            var trainingAssignment = new TrainingAssignment
            {
                EmployeeId = employeeId,
                TrainingId = trainingId,
                CompletedTraining = false,
                DateCompleted = null
            };

            _fastFoodDbContext.TrainingAssignments.Add(trainingAssignment);
            _fastFoodDbContext.SaveChanges();

            return Ok();
        }
    }

    public class AssignShiftRequest
    {
        public int ShiftId { get; set; }
        public DateTime ShiftDate { get; set; }
    }
}
