using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Entities;
using FastFoodAPI.Messages;


namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ShiftManagementController : ControllerBase
    {
        public ILogger<ShiftManagementController> _logger;
        private readonly FastFoodDbContext _fastFoodDbContext;


        public ShiftManagementController(ILogger<ShiftManagementController> logger, FastFoodDbContext fastFoodDbContext)
        {
            _logger = logger;
            _fastFoodDbContext = fastFoodDbContext;
        }


        /// <summary>
        /// This method updates the current training module boolean
        /// to indicate it has been completed.
        /// </summary>
        [HttpPatch("employees/completedtrainings/{employeeId}/{trainingModuleId:int}")]
        public IActionResult UpdateTrainingModule(string employeeId, int trainingModuleId)
        {
            // First step is to find the employee.
            var employee = _fastFoodDbContext.Employees
                .FirstOrDefault(e => e.Id == employeeId);
            // The next step is to check for the training module that is being completed.
            var trainingModule = _fastFoodDbContext.TrainingAssignments
                .FirstOrDefault(tm => tm.TrainingId == trainingModuleId);
            // And finally, set the boolean to true for completed training module.
            trainingModule.CompletedTraining = true;
            trainingModule.DateCompleted = DateTime.Now;

            // Now we save changes to the database and return Ok.
            _fastFoodDbContext.Update(trainingModule);
            _fastFoodDbContext.SaveChanges();

            return Ok();
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
        /// This method is used for updating the shift of an employee.
        /// </summary>
        [HttpPatch("employees/shifts/{employeeId}/{shiftId}")]
        public IActionResult UpdateShiftForEmployee(string employeeId, int shiftId)
        {
            // Find the employee By Id.
            var employee = _fastFoodDbContext.Employees
                .FirstOrDefault(e => e.Id == employeeId);
            // Now we need to assign the new shift based on the ID that we were given.
            var shift = _fastFoodDbContext.Shifts
                .FirstOrDefault(s => s.ShiftId == shiftId);
            // Now we save to the database and return Ok.
            _fastFoodDbContext.Update(employee);
            _fastFoodDbContext.SaveChanges();

            return Ok();
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
}

