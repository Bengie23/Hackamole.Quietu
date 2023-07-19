using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPrincipalRepository, PrincipalRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection SetupDatabase(this IServiceCollection services)
        {
            services.AddDbContext<QuietuDbContext>();
            services.AddTransient<DbInitializer>();
            services.AddTransient<QuietuSeeder>();

            return services;
        }

        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            services.AddScoped<ProductConsumptionQuery>();
            services.AddScoped<ProductDetailConsumptionQuery>();
            return services;
        }
    }
}
