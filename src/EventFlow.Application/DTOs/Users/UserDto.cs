using EventFlow.Application.DTOs.Events;

namespace EventFlow.Application.DTOs.Users;

public record UserDto(
    Guid Id,
    string UserName,
    string Email,
    DateTime CreatedDate,
    DateTime UpdatedDate,
    List<string> Roles,
    List<EventDto> OrganizedEvents
);
