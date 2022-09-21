using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPreferences.Commands.Create;

public class CreateContactPreferenceCommandValidator : AbstractValidator<CreateContactPreferenceCommand>
{

    public CreateContactPreferenceCommandValidator()
    {

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .NotEmpty().WithMessage("Name is required.");
    }

}
