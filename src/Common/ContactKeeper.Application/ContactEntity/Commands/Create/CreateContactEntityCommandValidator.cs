using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactEntity.Commands.Create;

public class CreateContactEntityCommandValidator : AbstractValidator<CreateContactEntityCommand>
{
    
    public CreateContactEntityCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .NotEmpty().WithMessage("Name is required.");
    }
}
