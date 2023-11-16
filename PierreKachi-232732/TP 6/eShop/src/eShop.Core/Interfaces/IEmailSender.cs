namespace eShop.Core.Interfaces
{
    public interface IEmailSender
    {
        bool SendEmail(string email, string subject, string message);
    }
}
