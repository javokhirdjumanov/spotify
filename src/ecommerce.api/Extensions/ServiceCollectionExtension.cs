namespace ecommerce.api.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApis(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
