using ecommerce.application.Applications.Messaging;

namespace ecommerce.application.Users.GetUserById;
public record GetUserByIdQuery(Guid id) : IQuery<GetUserByIdResponse>;
