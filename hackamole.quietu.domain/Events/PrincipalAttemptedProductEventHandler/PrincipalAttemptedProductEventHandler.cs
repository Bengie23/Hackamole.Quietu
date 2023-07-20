using System;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
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
            this.principalRepository = services.GetService<IPrincipalRepository>();
            this.logger = logger;
		}

        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            return new Task(() => { logger.LogInformation("AuthorizedEvent Received in handler PrincipalAttemptedProductEventHandler"); });
        }
    }
}

