namespace API.Helpers;
public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInDays { get; set; }
    public string SecurityKey { get; set; }
}
