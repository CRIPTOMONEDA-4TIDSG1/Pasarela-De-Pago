using Crypto.ArqLimpia.EN.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.ArqLimpia.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            DotEnv.LoadEnv();
            
            var host = Environment.GetEnvironmentVariable("HOST");
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");

            services.AddDbContext<CryptoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("conn")));
            services.AddScoped<IProduct, ProductDAL>();
            services.AddScoped<IUnitOfWork, UnitOfWork >();
            
            return services;
        }
        
    }

}
