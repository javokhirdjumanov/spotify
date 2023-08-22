using AutoMapper;
using Microsoft.EntityFrameworkCore;
using spotify.bizlayer.Abstractions;
using spotify.core.Shared;
using spotify.datalayer.Repositories;

namespace spotify.bizlayer.Services.Users;
public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, GetAllUserResponse>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Result<GetAllUserResponse>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
    {
        var users = userRepository.SelectAllAsync();
        var allUserResponse = new GetAllUserResponse(new List<AllUserResponse>());
        foreach (var item in users)
        {
            allUserResponse.allUsers.Add(
                mapper.Map<AllUserResponse>(item));
        }

        return allUserResponse;
    }
}
