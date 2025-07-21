using EventFlow.Application.DTOs.Users;
using EventFlow.Application.Mappers;
using EventFlow.Domain.Common;
using EventFlow.Domain.Repositories;
using MediatR;
namespace EventFlow.Application.Features.Users.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithRolesAndEventsAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return Error.Failure("User.NotFound", $"User with ID '{request.UserId}' was not found.");
        }

        return Result<UserDto>.Success(user.ToUserDto());
    }
}
