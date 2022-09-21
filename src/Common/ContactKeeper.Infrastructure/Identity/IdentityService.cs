using ContactKeeper.Application.Common.Exceptions;
using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Application.Dto;
using ContactKeeper.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ContactKeeper.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public IdentityService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<string> GetUserNameAsync(Guid userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            throw new UnauthorizeException();
        }

        return user.UserName;
    }

    public async Task<UserDto?> CheckUserPassword(string userName, string password)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);

        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            return _mapper.Map<UserDto>(user);
        }

        return null;
    }

    public async Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new User
        {
            UserName = userName
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> UserIsInRole(Guid userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<Result> DeleteUserAsync(Guid userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user != null)
        {
            return await DeleteUserAsync(user);
        }

        return Result.Success();
    }

    public async Task<Result> DeleteUserAsync(User user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
}
