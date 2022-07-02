namespace API.Services;
public class TokenService : ITokenService
{
    private readonly IOptions<JwtSettings> _config;

    public TokenService(IOptions<JwtSettings> config) => _config = config;

    public string CreateToken(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email)
        };

        var apiKeyValue = Encoding.ASCII.GetBytes(_config.Value.SecurityKey);

        var securityKey = new SymmetricSecurityKey(apiKeyValue);

        var signingCredes = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var jwt = new JwtSecurityToken(
                issuer: _config.Value.Issuer,
                audience: _config.Value.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(_config.Value.DurationInDays),
                signingCredentials: signingCredes
              );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
