using EventFlow.Domain.Common;
using MediatR;

namespace EventFlow.Application.Features.Auth.RegisterUser;

public record class RegisterUserCommand(string Email, string UserName, string Password) : IRequest<Result>;
