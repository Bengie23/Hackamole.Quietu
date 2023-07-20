using Hackamole.Quietu.Domain.Events;
using KafkaFlow;
using KafkaFlow.TypedHandler;

namespace Hackamole.Quietu.Authorization.Event.Handler.Bootstrap
{
    internal class ProductConsumptionCountEventHandler2 : IMessageHandler<AuthorizedEvent>
    {
        public Task Handle(IMessageContext context, AuthorizedEvent message)
        {
            throw new NotImplementedException();
        }
    }
}