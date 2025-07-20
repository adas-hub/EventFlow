using EventFlow.Application.Features.Events.GetEventDetails;
using EventFlow.Application.Features.Users.AssignUserRole;
using EventFlow.Application.Features.Users.GetUser;
using EventFlow.Application.Features.Users.RemoveUserRole;
using EventFlow.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EventFlow.Api.Controllers;

public class UsersController : BaseController
{
    [HttpPost("{userId:guid}/roles")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole(Guid userId, AssignUserRoleCommand command)
    {
        if (userId != command.UserId)
        {
            var error = Error.Failure("Validation.UserIdMismatch", "User ID in route must match user ID in the request body.");
            return HandleResult(new List<Error> { error });
        }

        var result = await Sender.Send(command);
        return HandleResult(result);
    }

    [HttpDelete("{userId:guid}/roles")]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> RemoveRole(Guid userId, [FromBody] RemoveUserRoleCommand command)
    {
        if (userId != command.UserId)
        {
            var error = Error.Failure("Validation.UserIdMismatch", "User ID in route must match user ID in the request body.");
            return HandleResult(new List<Error> { error });
        }

        var result = await Sender.Send(command);
        return HandleResult(result);
    }

    [HttpGet("{userId:guid}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        var query = new GetUserQuery(userId);
        var result = await Sender.Send(query);
        return HandleResult(result);
    }

}