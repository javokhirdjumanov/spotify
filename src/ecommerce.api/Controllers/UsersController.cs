using ecommerce.application.Users.GetAllUsers;
using ecommerce.application.Users.GetUserByAdrress;
using ecommerce.application.Users.GetUserById;
using ecommerce.domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers;
[Route("api/[controller]")]
public class UsersController : ApiController
{
    public UsersController(ISender sender) : base(sender)
    { }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        Result<GetUserByIdResponse> response = await this.sender
            .Send(query, cancellationToken);

        if (response.IsFailure)
            return HandleFailure(response);

        return Ok(response.Value);
    }

    [HttpGet("/address-of-user/userId:guid")]
    public async ValueTask<IActionResult> GetAddressByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetAddressByUserIdQuery(userId);

        Result<GetAddressByUserIdResponse> response = await this.sender
            .Send(query, cancellationToken);

        if (response.IsFailure)
        {
            return HandleFailure(response);
        }

        return Ok(response.Value);
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAllUser(CancellationToken cancellationToken)
    {
        var query = new GetAllUserQuery();

        Result<GetAllUserResponse> response = await this.sender
            .Send(query, cancellationToken);

        if (response.IsFailure)
        {
            return HandleFailure(response);
        }

        return Ok(response.Value);
    }
}
