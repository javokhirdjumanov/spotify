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
        var query = new Query(id: id);

        Result<Response> response = await this.sender.Send(query, cancellationToken);

        return response.IsSuccess 
            ? Ok(response) : BadRequest(response);
    }
}
