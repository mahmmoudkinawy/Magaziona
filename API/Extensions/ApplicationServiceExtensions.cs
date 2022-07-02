namespace API.Extensions;
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IDbInitializer, DbInitializer.DbInitializer>();

        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<MagazineDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
