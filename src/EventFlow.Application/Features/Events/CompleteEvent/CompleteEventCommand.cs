using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.CompleteEvent;

public record CompleteEventCommand(Guid EventId, Guid UserId, bool IsAdmin) : IRequest<Result>;
