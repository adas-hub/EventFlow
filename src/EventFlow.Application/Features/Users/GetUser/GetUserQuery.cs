using EventFlow.Application.DTOs.Users;
using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Users.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<Result<UserDto>>;
