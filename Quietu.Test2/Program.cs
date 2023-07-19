using System;
using System.Threading.Tasks;
using Hackamole.Quietu.Domain.Events.ProductConsumptionCountEvent;
using Hackamole.Quietu.Data;
using KafkaFlow;
using KafkaFlow.Producers;
using KafkaFlow.Serializer;
using KafkaFlow.TypedHandler;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.RegisterRepositories();
services.SetupDatabase();
services.AddKafka(
    kafka => kafka
        .AddCluster(
            cluster => cluster
                .WithBrokers(new[] { "localhost:9092" })
                .CreateTopicIfNotExists("AccessAuthorized", 6, 1)
                .AddConsumer(
                    consumer => consumer
                        .Topic("AccessAuthorized")
                        .WithGroupId("group-1")
                        .WithBufferSize(1000)
                        .WithWorkersCount(3)
                        .AddMiddlewares(
                            middlewares => middlewares
                                .AddSerializer<JsonCoreSerializer>()
                                .AddTypedHandlers(h => h.AddHandler<ProductConsumptionCountEventHandler>())
                        )
                )
        )
);

var provider = services.BuildServiceProvider();

var bus = provider.CreateKafkaBus();

await bus.StartAsync();

Console.WriteLine("Type the number of messages to produce or 'exit' to quit:");
