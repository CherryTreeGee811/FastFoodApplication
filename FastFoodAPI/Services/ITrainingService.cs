using FastFoodAPI.Entities;
using FastFoodAPI.Messages;

namespace FastFoodAPI.Services
{
    public interface ITrainingService
    {
        /// <summary>
        /// Gets all training assignments for a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <returns>A list of training assignments for the employee.</returns>
        Task<IEnumerable<TrainingModuleDTO>> GetEmployeeTrainingsAsync(string employeeId);

        /// <summary>
        /// Updates a training assignment status from incomplete to complete.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="trainingId">The ID of the training.</param>
        /// <returns>A tuple with the updated training module DTO, success status and error message if any.</returns>
        Task<(TrainingModuleDTO TrainingModule, bool Success, string ErrorMessage)> CompleteTrainingAsync(string employeeId, int trainingId);
    }
}
