using System;
using Customer.Domain.Interfaces.Repositories;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Services;
using Customer.Infra.Context;
using Customer.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.CrossCutting
{
	public static class IoC
	{
        public static IServiceCollection ConfigureContainer(this IServiceCollection services)
        {

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddSingleton<CustomerContext>();

            return services;
        }
    }
}

