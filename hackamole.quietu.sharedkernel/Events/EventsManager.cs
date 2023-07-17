using Hackamole.Quietu.SharedKernel.Events.configuration;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using KafkaFlow;
using KafkaFlow.Producers;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Hackamole.Quietu.SharedKernel.Events
{
    public class EventsManager<T> where T : IDomainEvent
    {
        private IMessageProducer messageProducer;
        private BusProviderConfiguration busProviderConfiguration;

        public EventsManager(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            busProviderConfiguration = configuration.GetSection("BusProvider").Get<BusProviderConfiguration>();
            var producerAccesor = serviceProvider.GetService(typeof(IProducerAccessor)) as IProducerAccessor;
            messageProducer = producerAccesor.GetProducer(busProviderConfiguration.Producer);
        }

        public void Raise(T raisedEvent)
        {
            messageProducer.Produce(busProviderConfiguration.Topic, Guid.NewGuid().ToString(), JsonSerializer.Serialize(raisedEvent));
        }
    }
}
