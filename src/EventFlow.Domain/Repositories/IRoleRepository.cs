using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;

namespace EventFlow.Domain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetRoleByNameAsync(string roleName, CancellationToken cancellationToken = default);
}
