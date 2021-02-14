using Microsoft.Extensions.DependencyInjection;
using Repository.GenericServices;
using Repository.RDBMS;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.AutoMapper;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IOperationServices<>), typeof(OperationServices<>));

            var config = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
