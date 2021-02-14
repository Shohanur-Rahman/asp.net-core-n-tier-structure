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
        public static IServiceCollection AddBlogBLLManager(this IServiceCollection services)
        {
            services.AddTransient<IBlogBLLManager, BlogBLLManager>();
            return services;
        }
    }
}
