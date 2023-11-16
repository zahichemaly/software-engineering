using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eShop.UnitTests
{
    public class EmailManagerTest
    {
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly Mock<IAppLogger<EmailManager>> _loggerMock;
        public EmailManagerTest()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _loggerMock = new Mock<IAppLogger<EmailManager>>();
        }


       /* [Fact]
        public void TrySend_ShouldReturnTrueIfEmailIsValidAndSubjectIsNotEmpty()
        {
            var email = "valid@email.com";
            var subject = "subject";
            var message = "body";
            var mockSender = new Mock<IEmailSender>();
            mockSender.Setup(x => x.SendEmail(email, subject, message)).Returns(true);
            var emailManager = new EmailManager(mockSender.Object, null);
            var result = emailManager.TrySend(email, subject, message);
            Assert.True(result);
        }*/

        /**/
        [Fact]
        public void TrySend_ShouldNotSendEmailIfAddressIsNotFromUSJ()
        {
            var emailManager = new EmailManager(new Mock<IEmailSender>().Object, new Mock<IAppLogger<EmailManager>>().Object);
            var email = "invalid-email-address@example.com";
            var subject = "This is a test email";
            var message = "This is the body of the email";

            bool emailSent = emailManager.TrySend(email, subject, message);

            Assert.False(emailSent);
        }
        /**/
        /*[Fact]
        public void TrySend_ShouldReturnFalseIfEmailIsInvalid()
        {
            var email = "invalid@email.com";
            var subject = "This is the subject";
            var message = "This is the body";
            var mockSender = new Mock<IEmailSender>();
            mockSender.Setup(x => x.SendEmail(email, subject, message)).Returns(true);
            var emailManager = new EmailManager(mockSender.Object, null);
            var result = emailManager.TrySend(email, subject, message);
            Assert.False(result);
        }*/

        [Fact]
        public void TrySend_ShouldReturnFalseIfSubjectIsEmpty()
        {
            var email = "valid@email.com";
            var subject = string.Empty;
            var message = "This is the body";
            var mockSender = new Mock<IEmailSender>();
            mockSender.Setup(x => x.SendEmail(email, subject, message)).Returns(true);
            var emailManager = new EmailManager(mockSender.Object, null);
            var result = emailManager.TrySend(email, subject, message);
            Assert.False(result);
        }
    }
}
