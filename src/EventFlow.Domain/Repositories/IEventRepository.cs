using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;

namespace EventFlow.Domain.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Task<Event?> GetByIdWithOrganizerAsync(Guid eventId, CancellationToken cancellationToken = default);
    Task<List<Event>> GetEventsByOrganizerIdAsync(Guid organizerId, CancellationToken cancellationToken = default);
}
