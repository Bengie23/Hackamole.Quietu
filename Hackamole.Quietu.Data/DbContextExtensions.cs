using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Data
{
    public static class DbContextExtensions
    {
        public static void InitializeDb(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var initializer = services.GetRequiredService<DbInitializer>();
            initializer.Run();
        }
    }
}
