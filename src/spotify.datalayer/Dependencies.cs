using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using spotify.datalayer.EfCode;
using spotify.datalayer.Options;
using spotify.datalayer.Repositories;

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
                    .GetConnectionString("DefaultConnectionString")!;

                options.UseNpgsql(connectionString);
            });

            services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

            AddRepositories(ref services);

            return services;
        }

        private static void AddRepositories(ref IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOtpCodeRepository, OtpCodeRepository>();
            services.AddTransient<IUserSessionRepository, UserSessionRepository>();
        }
    }
}
