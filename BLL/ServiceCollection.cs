using BLL.BLLManager;
using BLL.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ServiceCollection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBLLManager(this IServiceCollection services)
        {
            services.AddTransient<IUserBLLManager, UserBLLManager>();
            return services;
        }
    }
}
