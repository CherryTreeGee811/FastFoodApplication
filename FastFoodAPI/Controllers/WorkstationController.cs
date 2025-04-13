using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using Microsoft.AspNetCore.Mvc;


namespace FastFoodAPI.Controllers
{

    [ApiController]
    [Route("/api")]
    public class WorkstationController : ControllerBase
    {
        public ILogger<WorkstationController> _logger;
        private readonly FastFoodDbContext _fastFoodDbContext;


        public WorkstationController(ILogger<WorkstationController> logger, FastFoodDbContext fastFoodDbContext)
        {
            _logger = logger;
            _fastFoodDbContext = fastFoodDbContext;
            
        }

        
        /// <summary>
        /// This method returns all available stations.
        /// </summary>
        [HttpGet("employees/workstations")]
        public IActionResult GetStations()
        {
            var stations = _fastFoodDbContext.Stations.Select(station => new StationDTO
            {
                StationId = station.StationId,
                StationName = station.StationName
            }).ToList();
            return Ok(stations);
        }
        

        /// <summary>
        /// This method returns all available training modules.
        /// </summary>
        [HttpGet("employees/trainingmodules")]
        public IActionResult GetTrainingModules()
        {
            var trainingModules = _fastFoodDbContext.Trainings.Select(training => new TrainingModuleDTO
            {
                TrainingId = training.TrainingId,
                TrainingName = training.TrainingName
            }).ToList();
       
            return Ok(trainingModules);
        }
        

        /// <summary>
        /// Retrieve role for specific employee.
        /// </summary>
        [HttpGet("employees/roles/{id}")]
        public IActionResult GetEmployeeRole(int id)
        {
            var employeeRole = _fastFoodDbContext.Employees
                .Where(e => e.EmployeeId == id)
                .Select(e => new
                {
                    e.JobTitleId
                })
                .FirstOrDefault();
            
            return Ok(employeeRole);
        }
    }
}

