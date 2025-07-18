using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Users.RemoveUserRole;

public record RemoveUserRoleCommand(Guid UserId, string RoleName) : IRequest<Result>;
