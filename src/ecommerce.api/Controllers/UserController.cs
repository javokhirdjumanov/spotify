using ecommerce.application.Users.GetUserByAdrress;
using ecommerce.application.Users.GetUserById;
using ecommerce.domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers;
[Route("api/[controller]")]
public class UserController : ApiController
{
    public UserController(ISender sender) 
        : base(sender)
    { }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetUserById(
        Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        Result<GetUserByIdResponse> response = await this.sender
            .Send(query, cancellationToken);

        if(response.IsFailure)
            return HandleFailure(response);

        return Ok(response.Value);
    }

    [HttpGet("/address/userId:guid")]
    public async ValueTask<IActionResult> GetAddressByUserId(
        Guid userId,
        CancellationToken cancellationToken)
    {
        var query = new GetAddressByUserIdQuery(userId);

        Result<GetAddressByUserIdResponse> response = await this.sender
            .Send (query, cancellationToken);

        if(response.IsFailure)
        {
            return HandleFailure(response);
        }

        return Ok(response.Value);
    }
}
