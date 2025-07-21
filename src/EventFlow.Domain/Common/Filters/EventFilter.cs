using EventFlow.Domain.Enums;

namespace EventFlow.Domain.Common.Filters;

public record EventFilter(
    string? SearchTerm = null,
    string? Location = null,
    DateTime? StartDateFrom = null,
    DateTime? StartDateTo = null,
    EventStatus? Status = null,
    Guid? OrganizerId = null
);
