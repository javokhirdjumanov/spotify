using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace spotify.api.Controllers;
[Route("api/auth/[action]")]
[ApiController]
public class AuthController : ApiController
{
    public AuthController(ISender sender, IServiceProvider serviceProvider) 
        : base(sender, serviceProvider)
    { }


}
