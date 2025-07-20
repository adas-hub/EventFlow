using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.UpdateEvent;

public record UpdateEventCommand(
    Guid EventId,
    Guid UserId,
    bool IsAdmin,
    string Title,
    string Description,
    DateTime StartDate,
    DateTime EndDate,
    string Location,
    int MaxParticipants
) : IRequest<Result>;
