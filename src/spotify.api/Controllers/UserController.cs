using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace spotify.api.Controllers;
[Route("api/user/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUserList(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
