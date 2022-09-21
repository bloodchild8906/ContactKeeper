using ContactKeeper.Application.Dto;

namespace ContactKeeper.Application.Users.Queries;

public class LoginResponse
{
    public UserDto User { get; set; }

    public string Token { get; set; }
}
