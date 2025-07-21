using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Common;
using EventFlow.Domain.Common.Filters;
using MediatR;

namespace EventFlow.Application.Features.Events.GetPublishedEvents;

public record GetPublishedEventsQuery(
    Paging Paging,
    EventFilter Filter,
    Sorting Sorting
) : IRequest<Result<PagedResult<EventDto>>>;
