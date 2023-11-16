using eShop.Core.Interfaces;
using System.Net.Mail;

namespace eShop.Core.Managers
{
    public class EmailManager
    {
        protected readonly IEmailSender _sender;
        protected readonly IAppLogger<EmailManager> _logger;

        public EmailManager(IEmailSender sender, IAppLogger<EmailManager> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public bool TrySend(string email, string subject, string message)
        {
            if (IsValidEmail(email))
            {
                if (!string.IsNullOrEmpty(subject)) // subject should not be empty
                {
                    return _sender.SendEmail(email, subject, message);
                }
                return false;
            }
            return false;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                // Use MailAddress class to validate email format
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
