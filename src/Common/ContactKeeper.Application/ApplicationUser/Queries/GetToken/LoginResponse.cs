using ContactKeeper.Application.Dto;

namespace ContactKeeper.Application.ApplicationUser.Queries.GetToken;

public class LoginResponse
{
    public ApplicationUserDto User { get; set; }

    public string Token { get; set; }
}
