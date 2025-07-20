using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Entities;

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
}
