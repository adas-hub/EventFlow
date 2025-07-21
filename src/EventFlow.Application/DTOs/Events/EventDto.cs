namespace EventFlow.Application.DTOs.Events;

public record EventDto(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string Location,
    string Status,
    int MaxParticipants,
    Guid OrganizerId,
    string OrganizerUserName,
    int RegisteredParticipants
);
