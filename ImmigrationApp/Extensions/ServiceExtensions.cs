using ImmigrationApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationApp.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddModule(this IServiceCollection services, IConfiguration configuration)
		{
			services
				.AddScoped<ICompanyInfoServices, CompanyInfoService>();


			services.AddInfrastructure();
			
			return services;
		}
	}
	
}
