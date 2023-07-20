using System;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Domain.Events
{
	public class ProductCodeUsageEventHandler : IMessageHandler<AuthorizedEvent>
	{
        private readonly IProductRepository productRepository;

        public ProductCodeUsageEventHandler(IServiceProvider services)
		{
            this.productRepository = services.GetService<IProductRepository>();
		}

        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            return new Task(() => { productRepository.RegisterProductCodeUsage(message.ProductCode, message.Authorized); });
        }
    }
}

