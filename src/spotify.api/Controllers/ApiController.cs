using MediatR;
using Microsoft.AspNetCore.Mvc;
using spotify.core.Shared;

namespace spotify.api.Controllers;
[Route("api/auth[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    private readonly ISender sender;
    private readonly IServiceProvider serviceProvider;
    protected ApiController(ISender sender, IServiceProvider serviceProvider)
    {
        this.sender = sender;
        this.serviceProvider = serviceProvider;
    }
}
