using EventFlow.Domain.Entities;
using EventFlow.Domain.Interfaces;

namespace EventFlow.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetByIdWithRolesAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<User?> GetByIdWithRolesAndEventsAsync(Guid userId, CancellationToken cancellationToken = default);
}
