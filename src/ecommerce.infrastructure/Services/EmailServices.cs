using ecommerce.domain.Shared;
using ecommerce.infrastructure.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ecommerce.infrastructure.Services;
public sealed class EmailServices
{
    private readonly MailSettings mailSettings;
    public EmailServices(IOptions<MailSettings> options)
    {
        this.mailSettings = options.Value;
    }

    public async ValueTask SendEmailAsync(
        MailRequest mailRequest,
        CancellationToken cancellationToken)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(this.mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();

        using var smtpClient = new SmtpClient();

        await smtpClient.ConnectAsync(
            this.mailSettings.Host,
            this.mailSettings.Port,
            SecureSocketOptions.StartTls);

        await smtpClient.AuthenticateAsync(
            this.mailSettings.Mail,
            this.mailSettings.Password);

        await smtpClient.SendAsync(email, cancellationToken);

        await smtpClient.DisconnectAsync(true);
    }
}
