using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using spotify.bizlayer.Mapping;

namespace spotify.bizlayer;
public static class Dependencies
{
    public static IServiceCollection AddBizLayer(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddMediatR(typeof(Dependencies).Assembly);
        services.AddAutoMapper(typeof(MappingProfiles));

        //services.AddScoped<IPasswordHasher, PasswordHasher>();
        //services.Configure<JwtOptions>(configuration.GetSection("JwtSettings"));
        //services.AddTransient<IJwtTokenHandler, JwtTokenHandler>();
        //services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
