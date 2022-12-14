using ContactKeeper.Application.Common.Interfaces;
using ContactKeeper.Application.Common.Models;

namespace ContactKeeper.Application.Users.Queries;

public class GetTokenQuery :IRequestWrapper<LoginResponse>
{
    public string UserName { get; set; }

    public string Password { get; set; }
}

public class GetTokenQueryHandler : IRequestHandlerWrapper<GetTokenQuery, LoginResponse>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenService _tokenService;

    public GetTokenQueryHandler(IIdentityService identityService, ITokenService tokenService)
    {
        _identityService = identityService;
        _tokenService = tokenService;
    }

    public async Task<ServiceResult<LoginResponse>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
    {

        //todo: validate user here 
        var user = await _identityService.CheckUserPassword(request.UserName, request.Password);

        if (user == null)
            return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);


        return ServiceResult.Success(new LoginResponse
        {
            User = user,
            Token = _tokenService.CreateJwtSecurityToken(user.Id)
        });
    }

}
