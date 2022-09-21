using System;
using System.Security.Claims;
using ContactKeeper.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ContactKeeper.Api.Services;

/// <summary>
/// UserId
/// </summary>
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Current userId
    /// </summary>
    public Guid UserId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
}
