using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spotify.bizlayer.Services.Users;

namespace spotify.api.Controllers;
[Route("api/user/[action]")]
//[ApiController]
public class UserController : ApiController
{
    public UserController(ISender sender, IServiceProvider serviceProvider) 
        : base(sender, serviceProvider)
    { }

    [HttpGet]
    public async Task<IActionResult> GetUserList(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();

        var response = await HandleAsync<GetAllUserResponse, GetAllUsersQuery>(query, cancellationToken);

        if(response.IsFailure) return HandleFailure(response);

        return Ok(response.Value);
    }
}
