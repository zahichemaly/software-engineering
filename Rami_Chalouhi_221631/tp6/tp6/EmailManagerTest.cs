using System;

public class EmailManagerTest
{
    private readonly Mock<IEmailSender> _emailSenderMock;
    private readonly Mock<IAppLogger<EmailManager>> _loggerMock;
    public EmailManagerTest()
    {
        _emailSenderMock = new Mock<IEmailSender>();
        _loggerMock = new Mock<IAppLogger<EmailManager>>();
    }
}
