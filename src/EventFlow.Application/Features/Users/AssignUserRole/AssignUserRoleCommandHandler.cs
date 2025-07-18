﻿using EventFlow.Domain.Common;
using EventFlow.Domain.Repositories;
using MediatR;

namespace EventFlow.Application.Features.Users.AssignUserRole;

public class AssignUserRoleCommandHandler : IRequestHandler<AssignUserRoleCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignUserRoleCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdWithRolesAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return Error.Failure("User.NotFound", $"User with ID '{request.UserId}' was not found.");
        }

        var role = await _roleRepository.GetRoleByNameAsync(request.RoleName);
        if (role == null)
        {
            return Error.Failure("Role.NotFound", $"Role '{request.RoleName}' not found.");
        }

        if (user.Roles.Any(r => r.Name == request.RoleName))
        {
            return Error.Failure("User.RoleAlreadyAssigned.Conflic", $"User already has the role '{request.RoleName}'.");
        }

        user.Roles.Add(role);

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}