using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using Hackamole.Quietu.SharedKernel.Events.Options;
using KafkaFlow;
using KafkaFlow.Producers;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using KafkaFlow.Serializer.SchemaRegistry;

namespace Hackamole.Quietu.SharedKernel.Events
{
    public class EventsManager<T> : IEventsManager<T> where T : IDomainEvent
    {
        private IMessageProducer messageProducer;
        private BusProviderOptions busProviderConfiguration;

        public EventsManager(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            busProviderConfiguration = configuration.GetSection("BusProvider").Get<BusProviderOptions>();
            var producerAccesor = serviceProvider.GetService(typeof(IProducerAccessor)) as IProducerAccessor;
            messageProducer = producerAccesor.GetProducer(busProviderConfiguration.Producer);
        }

        public void Raise(T raisedEvent)
        {
            messageProducer.Produce(busProviderConfiguration.Topic, Guid.NewGuid().ToString(), raisedEvent);
        }
    }
}
