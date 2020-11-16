using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Infrastructure.Persistence;
using Portal.Infrastructure.Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.System
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>)); // AddScoped : Farklı isteklerde farklı instanceler oluşturur. Yani bir istekte oluşturulup dispose edilir.
            return services;
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortalDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Portal.Infrastructure")));

            services.AddScoped<DbContext>(provider => provider.GetService<PortalDbContext>());
            return services;
        }
        
    }
}
