using ecommerce.application.Applications.Messaging;
using ecommerce.domain.Entities;
using ecommerce.domain.Repositories;
using ecommerce.domain.Shared;

namespace ecommerce.application.Users.GetUserByAdrress;
public class GetAddressByUserIdQueryHandler 
    : IQueryHandler<GetAddressByUserIdQuery, GetAddressByUserIdResponse>
{
    private readonly IUserRepository userRepository;
    public GetAddressByUserIdQueryHandler(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result<GetAddressByUserIdResponse>> Handle(
        GetAddressByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var users = this.userRepository.GetAllUserWithAddress();

        var user = users.Result.Where(u => u.Id == request.userId).FirstOrDefault();

        if(user is null)
        {
            return Result
                .Failure<GetAddressByUserIdResponse>(
                new Error("User.NotFound", $"User with Id {request.userId} not found."));
        }

        var address =  new GetAddressByUserIdResponse(
            user.Id,
            user.Address.Id,
            user.Address.Country,
            user.Address.City,
            user.Address.Region,
            user.Address.Street,
            user.Address.PostalCode);

        return Result.Success<GetAddressByUserIdResponse>(address);
    }
}
