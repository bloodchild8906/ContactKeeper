using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.ContactEntity.Commands.Update;

public class UpdateContactEntityCommandValidator : AbstractValidator<UpdateContactEntityCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateContactEntityCommandValidator(IApplicationDbContext context)
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
        return await _context.ContactEntities.AllAsync(x => x.Name != name, cancellationToken);
    }
}
