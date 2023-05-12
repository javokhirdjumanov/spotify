using AutoMapper;
using ecommerce.application.Applications.Messaging;
using ecommerce.application.Users.GetUserById;
using ecommerce.domain.Repositories;
using ecommerce.domain.Shared;

namespace ecommerce.application.Users.GetAllUsers;
public class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, GetAllUserResponse>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public GetAllUserQueryHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Result<GetAllUserResponse>> Handle(
        GetAllUserQuery request,
        CancellationToken cancellationToken)
    {
        var users = await this.userRepository.SelectAllAsync(cancellationToken);

        var allUserResponse = new GetAllUserResponse(new List<GetUserByIdResponse>());

        foreach (var user in users)
        {
            allUserResponse.AllUsers
                .Add(mapper.Map<GetUserByIdResponse>(user));
        }

        return allUserResponse;
    }
}
