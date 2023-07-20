using System;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;

namespace Hackamole.Quietu.Domain.Events
{
	public class PrincipalAttemptedProductEventHandler : IDomainEventHandler<AuthorizedEvent>
	{
        private readonly IPrincipalRepository principalRepository;

        public PrincipalAttemptedProductEventHandler(IPrincipalRepository principalRepository)
		{
            this.principalRepository = principalRepository;
		}

        public void HandleEvent(AuthorizedEvent toHandleEvent)
        {
            principalRepository.RegisterPrincipalAttemptToAccessProduct(int.Parse(toHandleEvent.PrincipalId), toHandleEvent.ProductCode, toHandleEvent.Authorized);
        }
    }
}

