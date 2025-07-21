using EventFlow.Application.Features.Events.CancelEvent;
using EventFlow.Application.Features.Events.CompleteEvent;
using EventFlow.Application.Features.Events.CreateEvent;
using EventFlow.Application.Features.Events.GetEventDetails;
using EventFlow.Application.Features.Events.GetEvents;
using EventFlow.Application.Features.Events.GetMyOrganizedEvents;
using EventFlow.Application.Features.Events.GetPublishedEvents;
using EventFlow.Application.Features.Events.PublishEvent;
using EventFlow.Domain.Common;
using EventFlow.Domain.Common.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventFlow.Api.Controllers;

public class EventsController : BaseController
{

    [HttpPost]
    [Authorize(Roles = "Admin, Organizer")]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
    {
        var currentUserId = UserId!.Value;
        var commandWithOrganizer = command with { OrganizerId = currentUserId };
        var result = await Sender.Send(commandWithOrganizer);

        return HandleResult(result);
    }

    [HttpPost("{eventId:guid}/publish")]
    [Authorize(Roles = "Admin, Organizer")]
    public async Task<IActionResult> PublishEvent(Guid eventId)
    {
        var currentUserId = UserId!.Value;
        var isAdmin = User.IsInRole("Admin");
        var command = new PublishEventCommand(eventId, currentUserId, isAdmin);
        var result = await Sender.Send(command);

        return HandleResult(result);
    }

    [HttpPost("{eventId:guid}/cancel")]
    [Authorize(Roles = "Admin, Organizer")]
    public async Task<IActionResult> CancelEvent(Guid eventId)
    {
        var currentUserId = UserId!.Value;
        var isAdmin = User.IsInRole("Admin");
        var command = new CancelEventCommand(eventId, currentUserId, isAdmin);
        var result = await Sender.Send(command);

        return HandleResult(result);
    }

    [HttpPost("{eventId:guid}/complete")]
    [Authorize(Roles = "Admin, Organizer")]
    public async Task<IActionResult> CompleteEvent(Guid eventId)
    {
        var currentUserId = UserId!.Value;
        var isAdmin = User.IsInRole("Admin");
        var command = new CompleteEventCommand(eventId, currentUserId, isAdmin);
        var result = await Sender.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{eventId:guid}")]
    public async Task<IActionResult> GetEventDetails(Guid eventId)
    {
        var query = new GetEventDetailsQuery(eventId);
        var result = await Sender.Send(query);

        return HandleResult(result);
    }

    [HttpGet("my-organized")]
    [Authorize(Roles = "Admin, Organizer")]
    public async Task<IActionResult> GetMyOrganizedEvents()
    {
        var currentUserId = UserId!.Value;
        var query = new GetMyOrganizedEventsQuery(currentUserId);
        var result = await Sender.Send(query);

        return HandleResult(result);
    }
    [HttpGet("published")]
    public async Task<IActionResult> GetPublishedEvents(
        [FromQuery] Paging paging,
        [FromQuery] EventFilter filter,
        [FromQuery] Sorting sorting)
    {
        var query = new GetPublishedEventsQuery(paging, filter, sorting);
        var result = await Sender.Send(query);

        return HandleResult(result);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetEvents(
        [FromQuery] Paging paging,
        [FromQuery] EventFilter filter,
        [FromQuery] Sorting sorting)
    {
        var query = new GetEventsQuery(paging, filter, sorting);
        var result = await Sender.Send(query);

        return HandleResult(result);
    }

}
