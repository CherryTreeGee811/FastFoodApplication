using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using FastFoodAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ShiftManagementController(
        ILogger<ShiftManagementController> logger,
        FastFoodDbContext fastFoodDbContext,
        IShiftManagementService shiftManagementService,
        IMailService mailService,
        IEmployeeManagerService employeeManagerService) : ControllerBase
    {
        private readonly ILogger<ShiftManagementController> _logger = logger;
        private readonly FastFoodDbContext _fastFoodDbContext = fastFoodDbContext;
        private readonly IShiftManagementService _shiftManagementService = shiftManagementService;
        private readonly IMailService _mailService = mailService;
        private readonly IEmployeeManagerService _employeeManagerService = employeeManagerService;

        /// <summary>
        /// This method retrieves all available roles to the client.
        /// </summary>
        [HttpGet("employees/roles")]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = ("Manager,Cashier,Cook,Cleaner,Employee"))]
        public async Task<IActionResult> GetEmployeeShifts(string employeeId)
        {
            try
            {
                var shifts = await _shiftManagementService.GetEmployeeShiftsAsync(employeeId);
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving shifts for employee {EmployeeId}", employeeId);
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
        [Authorize(Roles = "Manager")]
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
                _logger.LogError(ex, "Error assigning shift for employee {EmployeeId}", employeeId);
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
        [Authorize(Roles = "Manager")]
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
                    ShiftPosition = shift?.ShiftPosition.ToString(),
                    EmployeeId = newShiftAssignment.EmployeeId,
                    ShiftDate = newShiftAssignment.ShiftDate
                };

                return Ok(shiftDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shift for employee {EmployeeId}", employeeId);
                return StatusCode(500, "An error occurred while updating the shift assignment.");
            }
        }

        /// <summary>
        /// This method allows us to assign a training module to an employee.
        /// </summary>
        [HttpPost("employees/trainingmodules/{employeeId}/{trainingId:int}")]
        [Authorize(Roles = "Manager")]
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
        
        /// <summary>
        /// This method sends an email to an employee with a list of their shifts.
        /// </summary>
        [HttpPost("employees/shifts/send-email/{employeeId}")]
        public async Task<IActionResult> SendShiftsEmail(string employeeId)
        {
            // First we need to find the employee's email so that
            // we can pass it to the service function.
            var employee = await _employeeManagerService.GetEmployee(employeeId);

            if (employee == null || string.IsNullOrEmpty(employee.EmailAddress))
            {
                return BadRequest("Employee not found or email address is missing.");
            }

            try
            {
                await _mailService.SendEmailAsync(employee.EmailAddress, employeeId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return Ok();
        }
        
        /// <summary>
        /// This method sends an email to all employees with a list of their shifts.
        /// </summary>
        [HttpPost("employees/shifts/send-email")]
        public async Task<IActionResult> SendShiftsEmailToAllEmployees()
        {
            // First, we need to get a list of all employees using the method
            // from the EmployeeManagerService.
            var employees  = await _employeeManagerService.GetAllEmployees();

            // Now we need to loop through all employees, call the service for emails,
            // and pass the ID of each employee to the method so that each employee
            // can get their shifts.
            foreach (var employee in employees)
            {
                if (!string.IsNullOrEmpty(employee.EmailAddress) && !string.IsNullOrEmpty(employee.EmployeeId))
                {
                    try
                    {
                        await _mailService.SendEmailAsync(employee.EmailAddress,
                                                          employee.EmployeeId);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            return Ok();
        }
    }
}
