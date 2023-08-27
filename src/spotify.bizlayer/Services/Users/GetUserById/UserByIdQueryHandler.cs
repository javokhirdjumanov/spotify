using AutoMapper;
using spotify.bizlayer.Abstractions;
using spotify.core.Errors;
using spotify.core.Shared;
using spotify.datalayer.EfClasses;
using spotify.datalayer.Repositories;

namespace spotify.bizlayer.Services.Users;
public class UserByIdQueryHandler : IQueryHandler<UserByIdQuery, UserByIdResponse>
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserByIdQueryHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<Result<UserByIdResponse>> Handle(
        UserByIdQuery request,
        CancellationToken cancellationToken)
    {
        User? storageUser = await this.userRepository
            .SelectByIdWithDetailsAsync(
                expression: user => user.Id == request.userId,
                includes: new string[] { nameof(User.Role), nameof(User.State), nameof(User.Status) });

        if (storageUser is null)
        {
            return Result.Failure<UserByIdResponse>(
                DomainError.User.NotFound(request.userId));
        }

        var response = new UserByIdResponse(
            storageUser.Id,
            storageUser.FirstName,
            storageUser.LastName,
            Phone: storageUser.Phone,
            storageUser.Email,
            new Manual.RoleResponse(storageUser.RoleId, storageUser.Role.RoleName),
            storageUser.RegisteredAt,
            new Manual.StatusResponse(storageUser.StatusId, storageUser.Status.StatusName),
            new Manual.StateResponse(storageUser.StateId ?? 0, storageUser.State.StateName ?? ""));

        return response;
    }
}
