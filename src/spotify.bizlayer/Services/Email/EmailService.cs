using AutoMapper.Internal;
using Microsoft.Extensions.Options;
using MimeKit;
using spotify.core.Shared;
using spotify.datalayer.Options;

namespace spotify.bizlayer.Services;
public sealed class EmailService : IEmailService
{
    private readonly MailSettings mailSettings;
    public EmailService(IOptions<MailSettings> options)
    {
        this.mailSettings = options.Value;
    }

    public Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();

        email.Sender = MailboxAddress.Parse(this.mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;

        throw new NotImplementedException();

    }
}
