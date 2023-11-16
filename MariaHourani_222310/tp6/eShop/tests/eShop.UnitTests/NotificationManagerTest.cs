using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Core.Entities;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using Xunit;

namespace eShop.UnitTests
{
    public class NotificationManagerTest
    {
        [Fact]
        public async Task SendEmailsToInactiveUsers_Should_SendEmails_ForInactiveUsers()
        {
            var userRepositoryMock = new Mock<IRepository<User>>();
            var emailSenderMock = new Mock<IEmailSender>();
            var loggerMock = new Mock<IAppLogger<EmailManager>>();

            var dummyUsers = new List<User>
            {
                new User { Id = "1", LastActive = DateTime.UtcNow.AddMonths(-2), Email = "user1@example.com" },
                new User { Id = "2", LastActive = DateTime.UtcNow.AddMonths(-1), Email = "user2@example.com" }
            };

            userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(dummyUsers);

            var notificationManager = new NotificationManager(emailSenderMock.Object, loggerMock.Object, userRepositoryMock.Object);

            await notificationManager.SendEmailsToInactiveUsers();

            emailSenderMock.Verify(
                //The number of calls to SendEmail should match the number of inactive users in the list.
                x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Exactly(dummyUsers.Count)
            );
        }

        [Fact]
        public async Task SendEmailsToInactiveUsers_Should_NotSendEmails_IfUserListIsEmpty()
        {
            var userRepositoryMock = new Mock<IRepository<User>>();
            var emailSenderMock = new Mock<IEmailSender>();
            var loggerMock = new Mock<IAppLogger<EmailManager>>();

            userRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<User>());

            var notificationManager = new NotificationManager(emailSenderMock.Object, loggerMock.Object, userRepositoryMock.Object);

            await notificationManager.SendEmailsToInactiveUsers();

            emailSenderMock.Verify(
                x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never()
                
            );
        }
    }
}
