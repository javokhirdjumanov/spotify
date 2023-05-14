using ecommerce.application.Users.DeleteUser;
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
    public UsersController(ISender sender, IServiceProvider serviceProvider) 
        : base(sender, serviceProvider)
    { }

    [HttpGet("{id:guid}")]
    public async ValueTask<IActionResult> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        var response = 
            await HandleAsync<GetUserByIdResponse, GetUserByIdQuery>(query, cancellationToken);

        if (response.IsFailure)
            return HandleFailure(response);

        return Ok(response.Value);
    }

    [HttpGet("/address-of-user/userId:guid")]
    public async ValueTask<IActionResult> GetAddressByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var query = new GetAddressByUserIdQuery(userId);

        var response =
            await HandleAsync<GetAddressByUserIdResponse, GetAddressByUserIdQuery>(query, cancellationToken);

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

        var response =
            await HandleAsync<GetAllUserResponse, GetAllUserQuery>(query, cancellationToken);

        if (response.IsFailure)
        {
            return HandleFailure(response);
        }

        return Ok(response.Value);
    }

    [HttpDelete("id:guid")]
    public async ValueTask<IActionResult> DeleteUser(
        Guid id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);

        Result<Guid> response = 
            await this.sender.Send(command, cancellationToken);

        if (response.IsFailure)
        {
            return HandleFailure(response);
        }

        return Ok(response.Value);
    }
}
