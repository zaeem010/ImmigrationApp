using ImmigrationApp.Repositries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Extensions
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories DI
            services
                .AddScoped<ICompanyInfoRepo, CompanyInfoRepo>();
               return services;
        }
    }
}
