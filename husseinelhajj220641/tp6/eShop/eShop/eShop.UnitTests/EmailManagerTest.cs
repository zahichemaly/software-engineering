using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
        public void TrySend_ValidEmailAndNonEmptySubject_ShouldSendEmail()
        {
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);

            _emailSenderMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            string validEmail = "example@net.usj.edu.lb";
            string nonEmptySubject = "Subjecttt";
            string message = "Hello world!";

            bool result = emailManager.TrySend(validEmail, nonEmptySubject, message);

            Assert.True(result);
            _emailSenderMock.Verify(x => x.SendEmail(validEmail, nonEmptySubject, message), Times.Once);

            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void TrySend_ValidEmailAndEmptySubject_ShouldNotSendEmail()
        {
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);

            string validEmail = "example@testing.com";
            string emptySubject = "";
            string message = "Hello world!";

            bool result = emailManager.TrySend(validEmail, emptySubject, message);

            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void TrySend_InvalidEmailAndNonEmptySubject_ShouldNotSendEmail()
        {
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);

            string invalidEmail = "invalidemail";
            string nonEmptySubject = "Subjectttt";
            string message = "Hello world!";

            bool result = emailManager.TrySend(invalidEmail, nonEmptySubject, message);

            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void TrySend_InvalidEmailAndEmptySubject_ShouldNotSendEmail()
        {
            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);

            string invalidEmail = "invalidemail";
            string emptySubject = "";
            string message = "Hello world!";

            bool result = emailManager.TrySend(invalidEmail, emptySubject, message);

            Assert.False(result);
            _emailSenderMock.Verify(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}
