
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Crypto.ArqLimpia.DAL;
using Crypto.ArqLimpia.BL;
using Crypto.ArqLimpia.BL.Interfaces;

namespace Crypto.ArqLimpia.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddInventoryDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderBL, OrderBL>();
            services.AddDALDependecies(configuration);
            services.AddBLDependecies();
        
            return services;
        }
    }
}
