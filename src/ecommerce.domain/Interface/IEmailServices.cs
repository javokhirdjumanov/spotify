using ecommerce.domain.Shared;

namespace ecommerce.domain.Interface;
public interface IEmailServices
{
    ValueTask SendEmailAsync(
        MailRequest mailRequest,
        CancellationToken cancellationToken);
}
