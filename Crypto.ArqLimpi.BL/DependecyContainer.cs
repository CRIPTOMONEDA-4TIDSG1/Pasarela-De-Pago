using Crypto.ArqLimpia.BL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Crypto.ArqLimpia.BL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services)
        {
            services.AddTransient<IProductBL, ProductBL>();
            services.AddTransient<IOrderBL, OrderBL>();
            return services;
        }
    }
}
