using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Target.Domain.Interfaces;
using Target.Infrastructure.Data.DataContext;
using Target.Infrastructure.Data.Repositories;

namespace Target.Site.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configurations)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IDataBaseService, DataBaseService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
        }
    }
}
