using ecommerce.application.Applications.Messaging;

namespace ecommerce.application.Users.DeleteUser;
public record DeleteUserCommand(Guid id) 
    : ICommand<Guid>;
