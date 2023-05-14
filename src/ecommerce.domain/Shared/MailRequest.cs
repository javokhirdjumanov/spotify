namespace ecommerce.domain.Shared
{
    public record MailRequest(string ToEmail, string Subject, string Body);
}
