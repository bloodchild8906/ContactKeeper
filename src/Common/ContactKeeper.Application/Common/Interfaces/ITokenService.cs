namespace ContactKeeper.Application.Common.Interfaces;

public interface ITokenService
{
    string CreateJwtSecurityToken(Guid id);
}
