﻿using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Events;
using Hackamole.Quietu.SharedKernel.Events.Options;
using KafkaFlow;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;

namespace Hackamole.Quietu.Authorization.Event.Handler.Bootstrap
{
    public static class RegisterBusProvider
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
                                    .WithAutoOffsetReset(AutoOffsetReset.Latest)
                                    .AddMiddlewares(middlewares =>
                                        middlewares
                                            .AddSerializer<JsonCoreSerializer>()
                                            .AddTypedHandlers(handler =>
                                                handler
                                                    .AddHandler<ProductCodeUsageEventHandler>()
                                                    .AddHandler<PrincipalAttemptedProductEventHandler>()
                                                    .WhenNoHandlerFound( context =>
                                                    {
                                                        Console.WriteLine(String.Format("Message not handled > partition: {0} > offset: {1}", context.ConsumerContext.Partition, context.ConsumerContext.Offset));
                                                    })
                                             )
                                    )
                            )
                    )
            );
        }



        public static IServiceCollection AddConnectionStringOptions(this IServiceCollection services, IConfiguration config)
        {
            ConnectionStringOptions connectionStringOptions = new ConnectionStringOptions();
            config.GetSection(ConnectionStringOptions.Route).Bind(connectionStringOptions);
            services.AddSingleton(connectionStringOptions);

            return services;
        }
    }
}
