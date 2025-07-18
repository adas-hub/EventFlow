using EventFlow.Domain.Enums;

namespace EventFlow.Domain.Entities;

public class Registration : Entity
{
    public RegistrationStatus Status { get; set; } = RegistrationStatus.Pending;
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public Guid EventId { get; set; }
    public Event Event { get; set; } = default!;
}
