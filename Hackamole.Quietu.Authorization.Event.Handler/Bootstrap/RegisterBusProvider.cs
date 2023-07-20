using Hackamole.Quietu.Domain.Events.ProductConsumptionByPrincipal;
using Hackamole.Quietu.Domain.Events.ProductConsumptionCountEvent;
using Hackamole.Quietu.SharedKernel.Events.Options;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;

namespace Hackamole.Quietu.Authorization.Event.Handler.Bootstrap
{
    internal static class RegisterBusProvider
    {
        public static void AddBusProvider(this IServiceCollection serviceCollection, IConfiguration config)
        {
            var busProviderConfiguration = config.GetSection("BusProvider").Get<BusProviderOptions>();
            serviceCollection.AddKafka(kafka =>
                kafka
                    .AddCluster(
                        cluster => cluster
                            .WithBrokers(new[] { busProviderConfiguration.Endpoint })
                            .AddConsumer(ConsumerBuilder =>
                                ConsumerBuilder
                                    .ManualAssignPartitions(busProviderConfiguration.Topic, new[] { 1 })
                                    .Topic(busProviderConfiguration.Topic)
                                    .WithGroupId("quietu-group")
                                    .WithName("hackamole-quietu-event-handler-1")
                                    .WithBufferSize(100)
                                    .WithWorkersCount(1)
                                    .WithoutStoringOffsets()
                                    .AddMiddlewares(middlewares =>
                                        middlewares
                                            .AddSerializer<JsonCoreSerializer>()
                                            .AddTypedHandlers(handler => 
                                                handler.AddHandler<ProductConsumptionCountEventHandler2>()
                                             )
                                    )
                            )
                    )
            );
        }
    }
}
