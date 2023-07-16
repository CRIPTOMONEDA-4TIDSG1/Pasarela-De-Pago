using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.ArqLimpia.BL; //AQUI DEBE IR using Crypto.ArqLimpia.BL.Interfaces; PERO NO LO RECONOCE.

using Microsoft.Extensions.DependencyInjection;

namespace Crypto.ArqLimpia.BL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddBLDependecies(this IServiceCollection services)
        {
            //services.AddTransient<, >();
            return services;
        }
    }
}
