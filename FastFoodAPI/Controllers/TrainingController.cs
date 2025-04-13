using FastFoodAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly ILogger<TrainingController> _logger;

        public TrainingController(ITrainingService trainingService, ILogger<TrainingController> logger)
        {
            _trainingService = trainingService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all trainings for a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A list of training assignments for the specified employee.</returns>
        [HttpGet("employees/{employeeId}/trainings")]
        public async Task<IActionResult> GetEmployeeTrainings(string employeeId)
        {
            try
            {
                var trainings = await _trainingService.GetEmployeeTrainingsAsync(employeeId);
                return Ok(trainings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving trainings for employee {employeeId}");
                return StatusCode(500, "An error occurred while retrieving employee trainings.");
            }
        }

        /// <summary>
        /// Marks a training as completed for a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>The updated training assignment if successful.</returns>
        [HttpPatch("employees/{employeeId}/trainings/{trainingId}/complete")]
        public async Task<IActionResult> CompleteTraining(string employeeId, int trainingId)
        {
            try
            {
                var (trainingModule, success, errorMessage) = await _trainingService.CompleteTrainingAsync(employeeId, trainingId);

                if (!success)
                {
                    if (errorMessage.Contains("not found"))
                    {
                        return NotFound(errorMessage);
                    }
                    return BadRequest(errorMessage);
                }

                return Ok(trainingModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error completing training {trainingId} for employee {employeeId}");
                return StatusCode(500, "An error occurred while updating the training status.");
            }
        }

    }
}
