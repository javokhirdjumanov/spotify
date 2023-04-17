using ecommerce.application.Applications.Messaging;

namespace ecommerce.application.Users.GetUserById;
public record Query(Guid id) : IQuery<Response>;
