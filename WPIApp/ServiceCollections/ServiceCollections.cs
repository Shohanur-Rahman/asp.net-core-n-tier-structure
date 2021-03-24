using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPIApp.IServices;
using WPIApp.Services;

namespace WPIApp.ServiceCollections
{
    public static class ServiceCollections
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<ISecurityService, SecurityService>();
            return services;
        }
    }
}
