namespace API.Services;
public interface ITokenService
{
    string CreateToken(IdentityUser user);
}
