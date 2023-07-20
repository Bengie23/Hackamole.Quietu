using Hackamole.Quietu.Domain.Events.ProductConsumptionCountEvent;
using Hackamole.Quietu.Data;
using KafkaFlow;
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
                .AddConsumer(
                    consumer => consumer
                        .Topic("quietu-authorized-access")
                        .WithGroupId("quietu-group")
                        .WithBufferSize(100)
                        .WithWorkersCount(2)
                        .WithAutoOffsetReset(AutoOffsetReset.Earliest)
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

Console.ReadKey();