using ecommerce.application.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;


namespace ecommerce.application;
public static class Dependencies
{
    public static IServiceCollection AddAplication(
        this IServiceCollection services)
    {
        services.AddMediatR(typeof(Dependencies).Assembly);

        services.AddAutoMapper(typeof(MappProfile));

        return services;
    }
}