using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateUserCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(BeUniqueName).WithMessage("The specified city already exists. If you just want to activate the city leave the name field blank!");

        RuleFor(v => v.Id).NotNull();
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        //TODO: Control by uppercase and CultureInfo
        return await _context.Users.AllAsync(x => x.UserName != name, cancellationToken);
    }
}
