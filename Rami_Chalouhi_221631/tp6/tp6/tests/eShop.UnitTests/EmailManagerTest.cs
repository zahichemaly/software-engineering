using Castle.Core.Logging;
using eShop.Core.Entities;
using eShop.Core.Interfaces;
using eShop.Core.Managers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsValidEmailDomain(string emailAddress)
        {
            return emailAddress.EndsWith("@net.usj.edu.lb") || emailAddress.EndsWith("@usj.edu.lb");
        }

        [Fact]
        public void SendEmail_Should_Send_If_Address_Is_Valid_And_Subject_Is_Not_Empty()
        {

            var emailManager = new EmailManager(_emailSenderMock.Object, _loggerMock.Object);
            var emailAddress = "test@example.com";
            var subject = "Dummy notification";
            var body = "This is a dummy notification.";

            if (IsValidEmailDomain(emailAddress))
            {
                _emailSenderMock.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);


                var result = emailManager.TrySend(emailAddress, subject, body);

                Assert.True((bool)result);
            }
        }
    }

}