using spotify.core.Shared;

namespace spotify.bizlayer.Services;
public interface IEmailService
{
    Task SendEmailAsync(MailRequest mailRequest, CancellationToken cancellationToken);
}
