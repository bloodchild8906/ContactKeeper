using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;

namespace ContactKeeper.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<UserDto?> CheckUserPassword(string userName, string password);
    Task<string> GetUserNameAsync(Guid userId);
    Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);

    Task<bool> UserIsInRole(Guid userId, string role);

    Task<Result> DeleteUserAsync(Guid userId);
}
