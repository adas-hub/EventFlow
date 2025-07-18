using EventFlow.Application.DTOs.Auth;
using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest<Result<AuthResponseDto>>;
