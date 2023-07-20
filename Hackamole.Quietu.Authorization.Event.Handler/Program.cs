using Hackamole.Quietu.Authorization.Event.Handler.Bootstrap;

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
                    //services.RegisterRepositories();
                    //services.SetupDatabase();
                    services.AddBusProvider(configuration);
                    services.AddHostedService<Worker>();
                })
                .Build();

            host.Run();
        }
    }
}