using FluentValidation;

namespace EventFlow.Application.Features.Events.GetMyOrganizedEvents;

public class GetMyOrganizedEventsQueryValidator : AbstractValidator<GetMyOrganizedEventsQuery>
{
    public GetMyOrganizedEventsQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
