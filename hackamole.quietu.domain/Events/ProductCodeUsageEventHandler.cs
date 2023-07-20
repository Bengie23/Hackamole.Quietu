using System;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;

namespace Hackamole.Quietu.Domain.Events
{
	public class ProductCodeUsageEventHandler : IDomainEventHandler<AuthorizedEvent>
	{
        private readonly IProductRepository productRepository;

        public ProductCodeUsageEventHandler(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

        public void HandleEvent(AuthorizedEvent authorizedEvent)
        {
            productRepository.RegisterProductCodeUsage(authorizedEvent.ProductCode,authorizedEvent.Authorized);
        }
    }
}

