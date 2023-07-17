using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Api.Models;

using System.Reflection;
using hackamole.quietu.domain.Commands;
using hackamole.quietu.SharedKernel.Interfaces.Commands;
using KafkaFlow.Producers;
using KafkaFlow;
using KafkaFlow.Serializer;
using Microsoft.Extensions.Configuration;
using Hackamole.Quietu.SharedKernel.Events.configuration;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

        var busProviderConfiguration = config.GetSection("BusProvider").Get<BusProviderConfiguration>();

        JWTManagerOptions jwtManagerOptions = new JWTManagerOptions();
        builder.Configuration.GetSection(nameof(JWTManagerOptions)).Bind(jwtManagerOptions);
        builder.Services.AddSingleton<JWTManagerOptions>(jwtManagerOptions);
        builder.Services.AddTransient<IJWTManager, JWTManager>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<ICommandHandler<AuthorizeCommand>, AuthorizeCommandHandler>();


        builder.Services.AddKafka(
            kafka => kafka
                .UseConsoleLog()
                .AddCluster(
                    cluster => cluster
                        .WithBrokers(new[] { busProviderConfiguration.Endpoint })
                        .CreateTopicIfNotExists(busProviderConfiguration.Topic, 1, 1)
                        .AddProducer(
                            busProviderConfiguration.Producer,
                            producer => producer
                                .DefaultTopic(busProviderConfiguration.Topic)
                                .AddMiddlewares(m =>
                                    m.AddSerializer<JsonCoreSerializer>()
                                    )
                        )
                )
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}