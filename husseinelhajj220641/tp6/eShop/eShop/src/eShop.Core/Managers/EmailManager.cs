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
                var addr = new MailAddress(email);
                return addr.Host.Equals("net.usj.edu.lb", StringComparison.OrdinalIgnoreCase) ||
                       addr.Host.Equals("usj.edu.lb", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
