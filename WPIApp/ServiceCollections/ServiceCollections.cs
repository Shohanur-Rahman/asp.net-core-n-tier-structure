using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServiceManager;
using WPIApp.ServiceManager;

namespace WPIApp.ServiceCollections
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            return services;
        }
    }
}
