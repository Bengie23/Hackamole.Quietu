using KafkaFlow;
using KafkaFlow.Serializer;
using hackamole.quietu.api.Authorization;
using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Options;
using Microsoft.OpenApi.Models;
using Hackamole.Quietu.SharedKernel.Events.Options;
using Hackamole.Quietu.Data;

namespace hackamole.quietu.api
{
	public static class ServiceCollectionExtensions
	{
		public static WebApplicationBuilder AddJwtOptions(this WebApplicationBuilder builder)
		{
            JWTManagerOptions jwtManagerOptions = new JWTManagerOptions();
            builder.Configuration.GetSection(nameof(JWTManagerOptions)).Bind(jwtManagerOptions);
            builder.Services.AddSingleton(jwtManagerOptions);

			return builder;
        }

        public static WebApplicationBuilder AddConnectionStringOptions(this WebApplicationBuilder builder)
        {
            ConnectionStringOptions connectionStringOptions = new ConnectionStringOptions();
            builder.Configuration.GetSection(ConnectionStringOptions.Route).Bind(connectionStringOptions);
            builder.Services.AddSingleton(connectionStringOptions);

            return builder;
        }

        public static WebApplicationBuilder AddBusProviderOptions(this WebApplicationBuilder builder)
        {
            var busProviderConfiguration = builder.Configuration.GetSection("BusProvider").Get<BusProviderOptions>();
            builder.Services.AddSingleton<BusProviderOptions>(busProviderConfiguration);

            return builder;
        }

        public static IServiceCollection AddJwtManager(this IServiceCollection services)
        {
            services.AddTransient<IJWTManager, JWTManager>();
            return services;
        }

        public static IServiceCollection AddAuthenticatedPrincipalProvider(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IAuthenticatedPrincipalProvider, AuthenticatedPrincipalProvider>();
            return services;
        }

        public static IServiceCollection AddAndConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
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

            return services;
        }

        public static IServiceCollection AddAndConfigureKafka(this IServiceCollection services)
        {
            var scope = services.BuildServiceProvider().CreateScope();
            var busProviderConfiguration = scope.ServiceProvider.GetService<BusProviderOptions>();

            services.AddKafka(
                kafka => kafka
                    .UseConsoleLog()
                    .AddCluster(
                        cluster => cluster
                            .WithBrokers(new[] { busProviderConfiguration.Endpoint })
                            .CreateTopicIfNotExists(busProviderConfiguration.Topic, 3, 1)
                            .AddProducer(
                                busProviderConfiguration.Producer,
                                producer => producer
                                    .DefaultTopic(busProviderConfiguration.Topic)
                                    .WithProducerConfig(new Confluent.Kafka.ProducerConfig { MessageMaxBytes = 2000000 })
                                    .AddMiddlewares(m =>
                                        m.AddSerializer<JsonCoreSerializer>()
                                    )
                            )
                    )
            );

            return services;
        }

        public static WebApplication UseQuietuMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseMiddleware<JwtMiddleware>();
            return webApplication;
        }

        public static WebApplication UseQuietuCORS(this WebApplication webApplication)
        {
            webApplication.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            return webApplication;
        }
	}
}

