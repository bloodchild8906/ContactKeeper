using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactPeople.Commands.Create;

public class CreateContactPersonCommandValidator : AbstractValidator<CreateContactPersonCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateContactPersonCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(BeUniqueName).WithMessage("The specified city already exists.")
            .NotEmpty().WithMessage("Name is required.");
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.ContactPeople.AllAsync(x => x.Name != name, cancellationToken);
    }
}
