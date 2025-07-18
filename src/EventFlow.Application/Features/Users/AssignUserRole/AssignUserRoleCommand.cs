using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Users.AssignUserRole;

public record AssignUserRoleCommand(Guid UserId, string RoleName) : IRequest<Result>;
