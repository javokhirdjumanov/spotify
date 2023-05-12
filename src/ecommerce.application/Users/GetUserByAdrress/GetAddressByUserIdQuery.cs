using ecommerce.application.Applications.Messaging;

namespace ecommerce.application.Users.GetUserByAdrress;
public record GetAddressByUserIdQuery(Guid userId) : IQuery<GetAddressByUserIdResponse>;
