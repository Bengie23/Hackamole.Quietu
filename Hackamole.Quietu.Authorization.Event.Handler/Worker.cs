using KafkaFlow;

namespace Hackamole.Quietu.Authorization.Event.Handler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IKafkaBus bus;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            bus = serviceProvider.CreateKafkaBus();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await bus.StartAsync(stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(2000, stoppingToken);
            }
            await bus.StopAsync();
        }
    }
}