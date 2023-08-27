using MediatR;
using Microsoft.AspNetCore.Mvc;
using spotify.bizlayer.Services.Users;

namespace spotify.api.Controllers;
[Route("api/user/[action]")]
public class UserController : ApiController
{
    public UserController(ISender sender, IServiceProvider serviceProvider)
        : base(sender, serviceProvider)
    { }

    [HttpGet]
    public async Task<IActionResult> GetUsersList(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();

        var response = await HandleAsync
            <GetAllUserResponse, GetAllUsersQuery>(query, cancellationToken);

        if (response.IsFailure)
            return HandleFailure(response);

        return Ok(response.Value);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(
        int userId,
        CancellationToken cancellationToken)
    {
        var query = new UserByIdQuery(userId);

        var response = await HandleAsync
            <UserByIdResponse, UserByIdQuery>(query, cancellationToken);

        if (response.IsFailure)
            return HandleFailure(response);

        return Ok(response.Value);
    }
}
