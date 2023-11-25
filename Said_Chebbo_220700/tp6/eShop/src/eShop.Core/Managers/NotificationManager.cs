using Ardalis.GuardClauses;
using eShop.Core.Entities;
using eShop.Core.Interfaces;

namespace eShop.Core.Managers
{
    public class NotificationManager : EmailManager
    {
        private readonly IRepository<User> _userRepository;

        public NotificationManager(IEmailSender sender, 
            IAppLogger<EmailManager> logger,
            IRepository<User> userRepository) : base(sender, logger)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Sends a reminder notifications to users who did not use the application in the past month.
        /// </summary>
        /// <returns></returns>
        public async Task SendEmailsToInactiveUsers()
        {
            var users = await _userRepository.GetAllAsync();
            Guard.Against.Null(users, nameof(users), "Users cannot be null");

            var inactiveUsers = users.Where(x => x.LastActive <= DateTime.UtcNow.AddMonths(-1));
            foreach (var user in inactiveUsers)
            {
                // Call the send from the email manager
                TrySend(user.Email,
                    $"We missed you {user.FirstName}...",
                    "We've missed having you with us!\n" +
                    "Your presence and engagement mean a lot to us, and we would love to welcome you back to our community.\n" +
                    "We're eager to see you enjoy the benefits and experiences we offer.\n" +
                    "Come back and be part of our exciting journey again!");
            }
        }
    }
}
