using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using spotify.datalayer.EfCode;

namespace spotify.datalayer
{
    public static class Dependencies
    {
        public static IServiceCollection AddDataLayer(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContextPool<EfCoreContext>(options =>
            {
                string connectionString = configuration
                    .GetConnectionString("DefaultConnectionString");

                options.UseNpgsql(connectionString);
            });

            //AddRepositories(services);

            return services;
        }
    }
    //private static void AddRepositories(IServiceCollection services)
    //{
        
    //}
}
