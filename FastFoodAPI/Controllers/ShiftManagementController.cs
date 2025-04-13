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
        [HttpPatch("employees/completedtrainings/{employeeId}/{trainingModuleId}")]
        public IActionResult UpdateTrainingModule(int employeeId, int trainingModuleId)
        {
            // First step is to find the employee.
            var employee = _fastFoodDbContext.Employees
                .FirstOrDefault(e => e.EmployeeId == employeeId);
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
    }
}

