using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Common;
using EventFlow.Domain.Common.Filters;
using MediatR;

namespace EventFlow.Application.Features.Events.GetEvents;

public record GetEventsQuery(Paging Paging, EventFilter Filter, Sorting Sorting) : IRequest<Result<PagedResult<EventDto>>>;