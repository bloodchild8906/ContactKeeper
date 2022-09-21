using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactCategory.Commands.Create;

public class CreateContactCategoryCommandValidator : AbstractValidator<ContactCategory.Commands.Create.CreateContactCategoryCommand>
{

    public CreateContactCategoryCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .NotEmpty().WithMessage("Name is required.");
    }

}
