using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Crypto.ArqLimpia.DAL;
using Crypto.ArqLimpia.BL;

namespace Crypto.ArqLimpia.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddInventoryDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALDependecies(configuration);
            services.AddBLDependecies();
            return services;
        }
    }
}
