using EventFlow.Domain.Enums;
using FluentValidation;

namespace EventFlow.Application.Features.Users.AssignUserRole;

public class AssignUserRoleCommandValidator : AbstractValidator<AssignUserRoleCommand>
{
    public AssignUserRoleCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("RoleName is required.")
            .Must(BeAValidRole).WithMessage("Invalid role name.");
    }

    private bool BeAValidRole(string roleName)
    {
        return Enum.TryParse(typeof(UserRoles), roleName, true, out _);
    }
}
