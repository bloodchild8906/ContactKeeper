using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Notes.Commands.Update;

public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateNoteCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MustAsync(BeUniqueName).WithMessage("The specified notes already exists. If you just want to activate the notes leave the name field blank!");

        RuleFor(v => v.Id).NotNull();
    }

    private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
    {
        //TODO: Control by uppercase and CultureInfo
        return await _context.Notes.AllAsync(x => x.Name != name, cancellationToken);
    }
}
