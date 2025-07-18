using EventFlow.Application.Features.Auth.Login;
using EventFlow.Application.Features.Auth.RegisterUser;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await Sender.Send(command);
        return HandleResult(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await Sender.Send(command);
        return HandleResult(result);
    }
}