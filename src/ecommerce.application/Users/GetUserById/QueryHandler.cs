using ecommerce.application.Applications.Messaging;
using ecommerce.domain.Entities;
using ecommerce.domain.Errors;
using ecommerce.domain.Repositories;
using ecommerce.domain.Shared;

namespace ecommerce.application.Users.GetUserById;
public class QueryHandler : IQueryHandler<Query, Response>
{
    private readonly IUserRepository userRepository;
    public QueryHandler(IUserRepository userRepository)
        => this.userRepository = userRepository;

    public async Task<Result<Response>> Handle(
        Query request,
        CancellationToken cancellationToken)
    {
        User? isUser = await this.userRepository.SelectAsync(
            entityIds: request.id,
            cancellationToken: cancellationToken); 

        if(isUser == null)
        {
            return Result.Failure<Response>(
                DomainErrors.Users.NotFound(request.id));
        }

        var response = new Response(
            isUser.Id,
            isUser.Fullname,
            isUser.Email,
            isUser.Username,
            isUser.Phonenumber,
            isUser.Password,
            ((int)isUser.Role),
            isUser.AddressId);

        return response;
    }
}
