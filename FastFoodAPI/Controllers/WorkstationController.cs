using FastFoodAPI.Entities;
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
        [HttpGet("employee/workstations")]
        public IActionResult GetStations()
        {
            var stations = _fastFoodDbContext.Stations.Select(station => new
            {
                station.StationId,
                station.StationName
            }).ToList();
            return Ok(stations);
        }
        
        /// <summary>
        /// This method returns all available training modules.
        /// </summary>
        [HttpGet("employee/trainingmodules")]
        public IActionResult GetTrainingModules()
        {
            var trainingModules = _fastFoodDbContext.Trainings.Select(training => new
            {
                training.TrainingId,
                training.TrainingName
            }).ToList();
           
            return Ok(trainingModules);
        }
        
        /// <summary>
        /// Retrieve role for specific employee.
        /// </summary>
        [HttpGet("employee/role/{id}")]
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

