﻿using ContactKeeper.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Application.UserRoles.Commands.Update;

public class UpdateUserRoleCommandValidator : AbstractValidator<UpdateUserRoleCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdateUserRoleCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .WithMessage("The specified city already exists. If you just want to activate the city leave the name field blank!");

        RuleFor(v => v.Id).NotNull();
    }
}
