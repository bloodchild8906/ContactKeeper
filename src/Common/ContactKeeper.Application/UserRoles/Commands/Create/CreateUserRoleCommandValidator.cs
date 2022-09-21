using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.UserRoles.Commands.Create;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateUserRoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(BeUniqueName).WithMessage("The specified city already exists.")
            .NotEmpty().WithMessage("Name is required.");
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        return await _context.UserRole.AllAsync(x => x.Name != name, cancellationToken);
    }
}
