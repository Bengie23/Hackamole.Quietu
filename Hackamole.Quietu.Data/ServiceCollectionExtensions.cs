using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Options;
using Hackamole.Quietu.Domain.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPrincipalRepository, PrincipalRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            var scope = services.BuildServiceProvider().CreateScope();
            var connStringOptions = scope.ServiceProvider.GetService<ConnectionStringOptions>();

            ArgumentNullException.ThrowIfNull(connStringOptions, nameof(connStringOptions));

            services.AddDbContext<QuietuDbContext>(options =>
            
                options.UseMySQL(connStringOptions.Quietu),
                ServiceLifetime.Transient
            );
            services.AddTransient<DbInitializer>();
            services.AddTransient<QuietuSeeder>();

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<ProductConsumptionQuery>();
            services.AddScoped<ProductDetailConsumptionQuery>();
            return services;
        }
    }
}
