namespace API.Services;
public interface ITokenService
{
    Task<string> CreateTokenAsync(IdentityUser user);
}
