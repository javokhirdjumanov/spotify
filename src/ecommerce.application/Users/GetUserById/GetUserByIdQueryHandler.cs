using ecommerce.application.Applications.Messaging;
using ecommerce.domain.Entities;
using ecommerce.domain.Errors;
using ecommerce.domain.Repositories;
using ecommerce.domain.Shared;

namespace ecommerce.application.Users.GetUserById;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUserRepository userRepository;
    public GetUserByIdQueryHandler(IUserRepository userRepository)
        => this.userRepository = userRepository;

    public async Task<Result<GetUserByIdResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        User? isUser = await this.userRepository.SelectAsync(
            entityIds: request.id,
            cancellationToken: cancellationToken); 

        if(isUser == null)
        {
            return
                Result.Failure<GetUserByIdResponse>(
                DomainErrors.Users.NotFound(request.id));
        }

        var response = new GetUserByIdResponse(
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
