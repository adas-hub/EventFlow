using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Entities;
using EventFlow.Domain.Enums;

namespace EventFlow.Application.Mappers;

public static class MappingConfig
{
    public static EventDto ToEventDto(this Event @event)
    {
        return new EventDto(
            Id: @event.Id,
            Title: @event.Title,
            Description: @event.Description,
            StartDate: @event.StartDate,
            EndDate: @event.EndDate,
            Location: @event.Location,
            Status: @event.Status.ToString(),
            MaxParticipants: @event.MaxParticipants,
            RegisteredParticipants: @event.Registrations.Count(r => r.Status == RegistrationStatus.Confirmed),
            OrganizerId: @event.OrganizerId,
            OrganizerUserName: @event.Organizer?.UserName ?? "Unknown Organizer"
        );
    }
}
