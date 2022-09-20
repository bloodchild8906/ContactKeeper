using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<bool> UserIsInRole(string userId, string role);

    Task<Result> DeleteUserAsync(string userId);
}
