using hackamole.quietu.api.Authorization;
using hackamole.quietu.domain.Commands;
using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Options;
using Hackamole.Quietu.SharedKernel.Events.Options;
using KafkaFlow;
using KafkaFlow.Serializer;
using Microsoft.OpenApi.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var busProviderConfiguration = builder.Configuration.GetSection("BusProvider").Get<BusProviderOptions>();

        JWTManagerOptions jwtManagerOptions = new JWTManagerOptions();
        builder.Configuration.GetSection(nameof(JWTManagerOptions)).Bind(jwtManagerOptions);
        builder.Services.AddSingleton<JWTManagerOptions>(jwtManagerOptions);
        builder.Services.AddTransient<IJWTManager, JWTManager>();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IAuthenticatedPrincipalProvider, AuthenticatedPrincipalProvider>();

        builder.Services.RegisterRepositories();
        builder.Services.SetupDatabase();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hackamole.Quietu", Version = "V1" });
            option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Make sure to enter a valid JWT token",
                Name = "Auth",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{ }
                }
            });
        });
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
                                .WithProducerConfig(new Confluent.Kafka.ProducerConfig { MessageMaxBytes = 2000000,  })
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

        //app.UseAuthorization();

        app.UseMiddleware<JwtMiddleware>();

        app.MapControllers();

        app.InitializeDb();

        app.Run();
    }
}