using Hackamole.Quietu.Authorization.Event.Handler.Bootstrap;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Interfaces;
using KafkaFlow;
using System.Runtime.CompilerServices;

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
                .ConfigureServices(async services =>
                {
                    services.AddLogging(logging => logging.AddConsole());
                    services.RegisterRepositories();
                    services.SetupDatabase();
                    services.AddBusProvider(configuration);
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}