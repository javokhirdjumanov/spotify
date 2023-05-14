using ecommerce.application.Applications.Messaging;
using ecommerce.domain.Errors;
using ecommerce.domain.Repositories;
using ecommerce.domain.Shared;

namespace ecommerce.application.Users.DeleteUser;
public class DeleteUserCommandHandler 
    : ICommandHandler<DeleteUserCommand, Guid>
{
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    public DeleteUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = await this.userRepository
            .SelectAsync(cancellationToken, request.id);

        if(user is null)
        {
            return Result
                .Failure<Guid>(DomainErrors.Users.NotFound(request.id));
        }

        this.userRepository.Delete(user);

        await this.unitOfWork.SaveChangesAsync();

        return request.id;
    }
}
