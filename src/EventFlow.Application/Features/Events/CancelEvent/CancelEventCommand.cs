using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.CancelEvent;

public record CancelEventCommand(Guid EventId, Guid UserId, bool IsAdmin) : IRequest<Result>;
