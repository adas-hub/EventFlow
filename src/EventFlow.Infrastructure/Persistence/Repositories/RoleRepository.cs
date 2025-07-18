using EventFlow.Domain.Entities;
using EventFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Infrastructure.Persistence.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Role?> GetRoleByNameAsync(string roleName)
    {
        return await _dbSet.FirstOrDefaultAsync(r => r.Name == roleName);
    }
}
