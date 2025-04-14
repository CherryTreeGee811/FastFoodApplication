using System.Net;
using System.Net.Mail;
using FastFoodAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace FastFoodAPI.Services
{
    public class MailService : IMailService
    {
        private FastFoodDbContext _context;
        
        public MailService(FastFoodDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Email the employee with the list of schedules.
        /// </summary>

        public async Task SendEmailAsync(string recipient, string employeeId)
        {
            // Predefined email variables:
            string fromAddress = "linuxisamazing025@gmail.com";
            
            var smtpClient = new SmtpClient("smtp.gmail.com") {
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, "gqgqxskqscqlclhf"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
            };
            
            // First we need to find the employee by the Id.
            var employee = await _context.Employees.FindAsync(employeeId);
            // Then we need to get a list of all the shifts associated with that employee.
            var shifts = await _context.ShiftAssignments
                .Include(s => s.Shift)
                .Where(s => s.EmployeeId == employeeId)
                .ToListAsync();
            
            string emailBody = "<h1>Your Shift Schedule</h1><p>Here are your shifts:</p><table border='1' cellpadding='10' cellspacing='0' style='border-collapse: collapse; width: 100%;'><thead><tr><th>Date</th><th>Shift</th></tr></thead><tbody>";
            foreach (var shift in shifts)
            {
                emailBody += $"<tr><td>{shift.ShiftDate:yyyy-MM-dd}</td><td>{shift.Shift.ShiftPosition}</td></tr>";
            }
            emailBody += "</tbody></table><p>If you have any questions, please contact your manager. With <3, TechNerd.</p>";
            // Now, we need to actually send the message! :)
            var mailMessage = new MailMessage()
            {
                From = new MailAddress(fromAddress),
                To = { new MailAddress(recipient) },
                Subject = "Your Shift Schedule",
                Body = emailBody,
                IsBodyHtml = true
            };
            // Now, we send the email.
            mailMessage.To.Add(recipient);
            smtpClient.Send(mailMessage);
        }
    }
}

