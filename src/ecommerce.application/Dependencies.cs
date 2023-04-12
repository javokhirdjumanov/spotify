using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.application;
public static class Dependencies
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Dependencies).Assembly);

        return services;
    }
}