using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Crypto.ArqLimpia.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CryptoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConn")));
         //   services.AddScoped<, >();

            return services;
        }
    }
}
