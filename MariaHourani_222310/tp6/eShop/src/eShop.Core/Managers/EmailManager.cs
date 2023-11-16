using eShop.Core.Interfaces;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace eShop.Core.Managers
{
    public class EmailManager
    {
        protected readonly IEmailSender _sender;
        protected readonly IAppLogger<EmailManager> _logger;
        private IAppLogger<EmailManager> object1;
        private IEmailSender object2;

        public EmailManager(IEmailSender sender, IAppLogger<EmailManager> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public EmailManager(IAppLogger<EmailManager> object1, IEmailSender object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public bool TrySend(string email, string subject, string message)
        {
            if (!IsValidEmail(email) || !IsValidEmailUSJ(email))
            {
                if (!string.IsNullOrEmpty(subject)) 
                {
                    return _sender.SendEmail(email, subject, message);
                }
                return false;
            }
            return false;
        }
        private static bool IsValidEmailUSJ(string email)
        {
            try
            {
                var addr = new MailAddress(email);

                return addr.Host.EndsWith("net.usj.edu.lb") || addr.Host.EndsWith("usj.edu.lb");
            }
            catch
            {
                return false;
            }
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
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
