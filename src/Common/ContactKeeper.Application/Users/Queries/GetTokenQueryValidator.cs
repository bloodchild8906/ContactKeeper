using FluentValidation;

namespace ContactKeeper.Application.Users.Queries;

public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
{

    //todo: setup login validators
    public GetTokenQueryValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty().WithMessage("Username is required.");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}
