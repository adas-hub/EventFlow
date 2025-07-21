using EventFlow.Domain.Entities;
using EventFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByIdWithRolesAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
                     .Include(u => u.Roles)
                     .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdWithRolesAndEventsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
                     .Include(u => u.Roles)
                     .Include(u => u.OrganizedEvents)
                     .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
    }

}
