using FastFoodAPI.Entities;
using FastFoodAPI.Messages;
using Microsoft.EntityFrameworkCore;


namespace FastFoodAPI.Services
{
    public class TrainingService(FastFoodDbContext dbContext) : ITrainingService
    {
        private readonly FastFoodDbContext _dbContext = dbContext;


        /// <summary>
        /// Gets all training assignments for a specific employee.
        /// </summary>
        public async Task<IEnumerable<TrainingModuleDTO>> GetEmployeeTrainingsAsync(string employeeId)
        {
            var trainings = await _dbContext.TrainingAssignments
                .Include(ta => ta.Training)
                .Where(ta => ta.EmployeeId == employeeId && ta.CompletedTraining == false)
                .Select(ta => new TrainingModuleDTO
                {
                    TrainingId = ta.TrainingId,
                    TrainingName = ta.Training != null 
                        ? ta.Training.TrainingName : "Unknown",
                    TrainingDescription = ta.Training != null 
                        ? ta.Training.TrainingDescription : "No description available",
                    CompletedTraining = ta.CompletedTraining,
                    DateCompleted = ta.DateCompleted
                })
                .ToListAsync();

            return trainings;
        }

        /// <summary>
        /// Updates a training assignment status from incomplete to complete.
        /// </summary>
        public async Task<(TrainingModuleDTO TrainingModule, bool Success, string ErrorMessage)> CompleteTrainingAsync(string employeeId, int trainingId)
        {
            // Find the training assignment
            var trainingAssignment = await _dbContext.TrainingAssignments
                .Include(ta => ta.Training)
                .FirstOrDefaultAsync(ta => ta.EmployeeId == employeeId && ta.TrainingId == trainingId);

            if (trainingAssignment == null)
            {
                return (null!, false, $"Training assignment not found for employee {employeeId} and training {trainingId}");
            }

            // Check if it's already completed
            if (trainingAssignment.CompletedTraining)
            {
                return (null!, false, "Training is already marked as completed");
            }

            // Mark as completed
            trainingAssignment.CompletedTraining = true;
            trainingAssignment.DateCompleted = DateTime.Now;

            // Save changes
            try
            {
                await _dbContext.SaveChangesAsync();

                // Create and return the DTO
                var trainingModuleDTO = new TrainingModuleDTO
                {
                    TrainingId = trainingAssignment.TrainingId,
                    TrainingName = trainingAssignment.Training?.TrainingName
                        ?? "Unknown",
                    TrainingDescription = trainingAssignment.Training?.TrainingDescription
                        ?? "No description available",
                    CompletedTraining = trainingAssignment.CompletedTraining,
                    DateCompleted = trainingAssignment.DateCompleted
                };

                return (trainingModuleDTO, true, string.Empty);
            }
            catch (Exception ex)
            {
                return (null!, false, $"Error updating training assignment: {ex.Message}");
            }
        }
    }
}
