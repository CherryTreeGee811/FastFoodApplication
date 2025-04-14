namespace FastFoodAPI.Services
{
    public interface IMailService
    {
        /// <summary>
        /// This interface defines the contract for sending emails.
        /// </summary>
        Task SendEmailAsync(string recipient, string employeeId);
        
    }
}

