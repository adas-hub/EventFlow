using EventFlow.Domain.Entities;
using EventFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Infrastructure.Persistence.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Event?> GetByIdWithOrganizerAsync(Guid eventId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(e => e.Organizer)
            .FirstOrDefaultAsync(e => e.Id == eventId, cancellationToken);
    }
    public async Task<List<Event>> GetEventsByOrganizerIdAsync(Guid organizerId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Where(e => e.OrganizerId == organizerId)
            .Include(e => e.Organizer)
            .ToListAsync(cancellationToken);
    }
}
