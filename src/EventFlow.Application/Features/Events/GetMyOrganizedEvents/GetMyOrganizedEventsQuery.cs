using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Events.GetMyOrganizedEvents;

public record GetMyOrganizedEventsQuery(Guid UserId) : IRequest<Result<List<EventDto>>>;