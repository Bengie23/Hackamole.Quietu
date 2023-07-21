using hackamole.quietu.domain.Commands;
using hackamole.quietu.SharedKernel.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<AuthorizeCommand>, AuthorizeCommandHandler>();
            return services;
        }
    }
}

