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
    public GetAllUsersQueryHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Result<GetAllUserResponse>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
    {
        var storageUsers = userRepository
            .SelectAllAsync()
            .Include(u => u.Status)
            .Include(u => u.Role)
            .ToList();

        var users = storageUsers
            .Select(user => new UserResponse(
                                user.FirstName ?? "",
                                user.LastName ?? "",
                                user.Phone ?? "",
                                user.Email ?? "",
                                user.Role.RoleName ?? "",
                                user.Status.StatusName ?? ""
                            )
                    )
            .ToList();

        return Result<GetAllUserResponse>
            .Success(new GetAllUserResponse(users));
    }
}
