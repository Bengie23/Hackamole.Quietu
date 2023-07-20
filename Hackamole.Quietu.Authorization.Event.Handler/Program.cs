using Hackamole.Quietu.Authorization.Event.Handler.Bootstrap;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Interfaces;

namespace Hackamole.Quietu.Authorization.Event.Handler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddLogging(logging => logging.AddConsole());
                    //services.SetupDatabase();
                    //services.RegisterRepositories();
                    //services.RegisterQueries();
                    services.AddDbContext<QuietuDbContext>();
                    services.AddTransient<DbInitializer>();
                    services.AddTransient<QuietuSeeder>();
                    services.AddTransient<IPrincipalRepository, PrincipalRepository>();
                    services.AddTransient<IProductRepository, ProductRepository>();
                    services.AddBusProvider(configuration);
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}