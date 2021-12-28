using Ecommerce.BLL;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Database.Database;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ecommerce.Configuration
{
    public static class ConfigureService
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerTypeManager, CustomerTypeManager>();
            services.AddTransient<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddTransient<DbContext, EcommerceDbContext>();
            
        }
    }
}
