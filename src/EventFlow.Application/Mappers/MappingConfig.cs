using EventFlow.Application.DTOs.Events;
using EventFlow.Application.DTOs.Users;
using EventFlow.Domain.Entities;
using System.Data;

namespace EventFlow.Application.Mappers;

public static class MappingConfig
{
    public static EventDto ToEventDto(this Event @event)
    {
        return new EventDto(
            @event.Id,
            @event.Title,
            @event.Description,
            @event.StartDate,
            @event.EndDate,
            @event.Location,
            @event.Status.ToString(),
            @event.MaxParticipants,
            @event.OrganizerId,
            @event.Organizer?.UserName ?? "Unknown Organizer"
        );
    }

    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.UserName,
            user.Email,
            user.CreatedDate,
            user.UpdatedDate,
            user.Roles.Select(r => r.Name).ToList(),
            user.OrganizedEvents.Select(e => e.ToEventDto()).ToList()
        );
    }
}
