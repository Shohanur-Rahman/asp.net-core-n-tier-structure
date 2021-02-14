using Microsoft.Extensions.DependencyInjection;
using ServiceManager.BLLManager;
using ServiceManager.IManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceManager
{
    public static class ServiceManagerCollectionExtension
    {
        public static IServiceCollection AddServiceManager(this IServiceCollection services)
        {
            services.AddTransient<IBlogManager, BlogManager>();
            return services;
        }
    }
}
