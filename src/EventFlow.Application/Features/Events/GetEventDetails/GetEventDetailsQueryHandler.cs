using EventFlow.Application.DTOs.Events;
using EventFlow.Application.Mappers;
using EventFlow.Domain.Common;
using EventFlow.Domain.Repositories;
using MediatR;

namespace EventFlow.Application.Features.Events.GetEventDetails;

public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, Result<EventDto>>
{
    private readonly IEventRepository _eventRepository;

    public GetEventDetailsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<EventDto>> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdWithOrganizerAsync(request.EventId, cancellationToken);

        if (@event == null)
        {
            return Error.Failure("Event.NotFound", $"Event with ID '{request.EventId}' was not found.");
        }

        var eventDetailsDto = @event.ToEventDto();

        return Result<EventDto>.Success(eventDetailsDto);
    }
}
