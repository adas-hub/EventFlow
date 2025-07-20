using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.CreateEvent
{
    public record CreateEventCommand(
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Location,
        int MaxParticipants,
        Guid OrganizerId
    ) : IRequest<Result<Guid>>;
}
