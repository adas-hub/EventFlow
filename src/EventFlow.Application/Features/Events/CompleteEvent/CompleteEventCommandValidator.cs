using FluentValidation;

namespace EventFlow.Application.Features.Events.CompleteEvent;
public class CompleteEventCommandValidator : AbstractValidator<CompleteEventCommand>
{
    public CompleteEventCommandValidator()
    {
        RuleFor(x => x.EventId)
            .NotEmpty().WithMessage("Event ID is required.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}