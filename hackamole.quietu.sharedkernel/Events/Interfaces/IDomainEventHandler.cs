using KafkaFlow.TypedHandler;

namespace Hackamole.Quietu.SharedKernel.Events.Interfaces
{
    public interface IDomainEventHandler<T> where T : IDomainEvent, IMessageHandler<T>
    {
    }
}
