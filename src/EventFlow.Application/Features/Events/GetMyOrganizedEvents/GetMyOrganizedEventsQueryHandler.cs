using EventFlow.Application.DTOs.Events;
using EventFlow.Application.Mappers;
using EventFlow.Domain.Common;
using EventFlow.Domain.Repositories;
using MediatR;

namespace EventFlow.Application.Features.Events.GetMyOrganizedEvents;

public class GetMyOrganizedEventsQueryHandler : IRequestHandler<GetMyOrganizedEventsQuery, Result<List<EventDto>>>
{
    private readonly IEventRepository _eventRepository;

    public GetMyOrganizedEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<List<EventDto>>> Handle(GetMyOrganizedEventsQuery request, CancellationToken cancellationToken)
    {
        var organizedEvents = await _eventRepository.GetEventsByOrganizerIdAsync(request.UserId, cancellationToken);

        var eventSummaries = organizedEvents
            .Select(e => e.ToEventDto())
            .ToList();

        return Result<List<EventDto>>.Success(eventSummaries);
    }
}
