using System.ComponentModel;

namespace spotify.api;
public static class Dependencies
{
    public static IServiceCollection AddApis(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));

        //services.AddSwagger();

        services.AddAuthentication();

        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
