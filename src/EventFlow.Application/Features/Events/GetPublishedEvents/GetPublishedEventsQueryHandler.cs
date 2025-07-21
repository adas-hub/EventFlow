using EventFlow.Application.DTOs.Events;
using EventFlow.Application.Mappers;
using EventFlow.Domain.Common;
using EventFlow.Domain.Enums;
using EventFlow.Domain.Repositories;
using MediatR;

namespace EventFlow.Application.Features.Events.GetPublishedEvents;

public class GetPublishedEventsQueryHandler : IRequestHandler<GetPublishedEventsQuery, Result<PagedResult<EventDto>>>
{
    private readonly IEventRepository _eventRepository;

    public GetPublishedEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<PagedResult<EventDto>>> Handle(GetPublishedEventsQuery request, CancellationToken cancellationToken)
    {
        var pagedEvents = await _eventRepository.GetEventsAsync(
            request.Paging,
            request.Filter with { Status = EventStatus.Published },
            request.Sorting,
            cancellationToken);

        var eventDtos = pagedEvents.Items.Select(e => e.ToEventDto()).ToList();

        var result = new PagedResult<EventDto>
        {
            Items = eventDtos,
            TotalCount = pagedEvents.TotalCount,
            PageNumber = pagedEvents.PageNumber,
            PageSize = pagedEvents.PageSize
        };

        return Result<PagedResult<EventDto>>.Success(result);
    }
}