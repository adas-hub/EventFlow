using EventFlow.Domain.Entities;

namespace EventFlow.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
