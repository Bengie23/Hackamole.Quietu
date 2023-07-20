using Hackamole.Quietu.Domain.Interfaces;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hackamole.Quietu.Domain.Events
{
    public class PrincipalAttemptedProductEventHandler : IMessageHandler<AuthorizedEvent>
	{
        private readonly IPrincipalRepository principalRepository;
        private readonly ILogger<PrincipalAttemptedProductEventHandler> logger;

        public PrincipalAttemptedProductEventHandler(ILogger<PrincipalAttemptedProductEventHandler> logger, IServiceProvider services)
		{
            var scope = services.CreateScope();
            this.principalRepository = scope.ServiceProvider.GetService<IPrincipalRepository>();
		}

        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            principalRepository.RegisterPrincipalAttemptToAccessProduct(int.Parse(message.PrincipalId), message.ProductCode, message.Authorized);
            return Task.CompletedTask;
        }
    }
}

