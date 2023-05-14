using ecommerce.domain.Interface;
using ecommerce.domain.Repositories;
using ecommerce.domain.Repositories.Base;
using ecommerce.infrastructure.Options;
using ecommerce.infrastructure.Persistence;
using ecommerce.infrastructure.Persistence.Repositories;
using ecommerce.infrastructure.Services;
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
            string connectionString = 
            configuration.GetConnectionString("SqlServer");

            options.UseSqlServer(
                connectionString: connectionString,
                sqlServerOptionsAction: options => options.EnableRetryOnFailure());
        });

        // services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddTransient<IEmailServices, EmailServices>();

        RegisterRepositories(services);
    }
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
    }
}
