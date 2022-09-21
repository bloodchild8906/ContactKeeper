using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.Notes.Commands.Create;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateNoteCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .NotEmpty().WithMessage("Name is required.");
    }
}
