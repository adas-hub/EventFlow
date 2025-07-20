using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.PublishEvent;

public record PublishEventCommand(Guid EventId, Guid UserId, bool IsAdmin) : IRequest<Result>;
