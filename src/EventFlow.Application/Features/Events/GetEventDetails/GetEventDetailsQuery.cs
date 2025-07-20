using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.GetEventDetails;

public record GetEventDetailsQuery(Guid EventId) : IRequest<Result<EventDto>>;
