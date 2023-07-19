using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackamole.Quietu.Domain.Events.ProductConsumptionByPrincipal
{
    public class ProductConsumptionByPrincipalEventHandler : IMessageHandler<AuthorizedEvent>
    {
        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
