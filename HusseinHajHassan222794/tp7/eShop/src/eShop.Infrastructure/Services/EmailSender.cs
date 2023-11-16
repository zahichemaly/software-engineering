using eShop.Core.Interfaces;

namespace eShop.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public bool SendEmail(string email, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
            Console.WriteLine($"Sending email to {email} with subject \"{subject}\" and message: \"{message}\"");
            return true;
        }
    }
}
