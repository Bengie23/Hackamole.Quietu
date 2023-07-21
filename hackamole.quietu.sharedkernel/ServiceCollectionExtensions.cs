using hackamole.quietu.SharedKernel.Commands;
using Hackamole.Quietu.SharedKernel.Commands.Interfaces;
using Hackamole.Quietu.SharedKernel.Events;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.SharedKernel
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCommandsAndEventsManagers(this IServiceCollection services)
		{
            services.AddTransient(typeof(ICommandsManager<>), typeof(CommandsManager<>));
            services.AddTransient(typeof(IEventsManager<>), typeof(EventsManager<>));
			return services;
        }
	}
}

