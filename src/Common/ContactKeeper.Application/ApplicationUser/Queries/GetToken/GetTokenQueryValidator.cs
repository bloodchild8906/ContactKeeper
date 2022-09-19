using FluentValidation;

namespace ContactKeeper.Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQueryValidator : AbstractValidator<GetTokenQuery>
    {

        //todo: setup login validators
        public GetTokenQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.")
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
