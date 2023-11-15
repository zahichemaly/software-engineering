using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;

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



        [Fact]
        public void TrySend_Should_Return_True_When_Email_Is_Valid_And_Subject_Is_Not_Empty()
        {
            var email = "test@usj.edu.lb";
            var subject = "Test Subject";
            var message = "Test Message";
            _emailSenderMock.Setup(x => x.SendEmail(email, subject, message)).Returns(true);
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);

            var result = emailManager.TrySend(email, subject, message);

            Assert.True(result);
            _emailSenderMock.Verify(x => x.SendEmail(email, subject, message), Times.Once);
        }

        [Fact]
        public void TrySend_Should_Return_False_When_Email_Is_Invalid()
        {
            var email = "invalid_email";
            var subject = "Test Subject";
            var message = "Test Message";
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);
            var result = emailManager.TrySend(email, subject, message);
            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(email, subject, message), Times.Never);
        }

        [Fact]
        public void TrySend_Should_Return_False_When_Subject_Is_Empty()
        {
            var email = "test@usj.edu.lb";
            var subject = "";
            var message = "Test Message";
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);
            var result = emailManager.TrySend(email, subject, message);
            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(email, subject, message), Times.Never);
        }
        [Fact]
        public void TrySend_Should_Return_False_When_Email_Is_Not_From_USJ()
        {
            var email = "test@notusj.edu.lb";
            var subject = "Test Subject";
            var message = "Test Message";
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);
            var result = emailManager.TrySend(email, subject, message);
            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(email, subject, message), Times.Never); 
    }

    }

}

