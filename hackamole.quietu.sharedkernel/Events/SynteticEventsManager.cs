using System;
using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;

namespace Hackamole.Quietu.SharedKernel.Events
{
	public class SynteticEventsManager<T> : IEventsManager<T> where T : IDomainEvent
    {
        private readonly IServiceProvider serviceProvider;

        public SynteticEventsManager(IServiceProvider serviceProvider)
		{
            this.serviceProvider = serviceProvider;
		}

        public void Raise(T raisedEvent)
        {
            var type = typeof(IDomainEventHandler<>);
            Type[] typeArgs = { raisedEvent.GetType() };
            Type factoryType = type.MakeGenericType(typeArgs);

            if (serviceProvider != null)
            {
                Type? genericEnumerable = typeof(IEnumerable<>).MakeGenericType(factoryType);
                IEnumerable<object> eventHandlers = (IEnumerable<object>)serviceProvider.GetService(genericEnumerable);
                foreach (dynamic handler in eventHandlers)
                {
                    handler.HandleEvent(raisedEvent);
                }
            }
        }
    }
}

