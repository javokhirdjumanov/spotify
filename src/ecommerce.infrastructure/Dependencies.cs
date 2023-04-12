using ecommerce.domain.Repositories;
using ecommerce.domain.Repositories.Base;
using ecommerce.infrastructure.Persistence;
using ecommerce.infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.infrastructure;
public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        return services;
    }
    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<ApplicationDBContext>(options =>
        {
            string connectionString = configuration.GetConnectionString("SqlServer");

            options.UseSqlServer(
                connectionString: connectionString,
                sqlServerOptionsAction: options => options.EnableRetryOnFailure());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
    }
}
