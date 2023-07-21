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
                    services.AddConnectionStringOptions(configuration);
                    services.AddLogging(logging => logging.AddConsole());
                    services.AddDatabase();
                    services.AddRepositories();
                    services.AddQueries();
                    services.AddBusProvider(configuration);
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}