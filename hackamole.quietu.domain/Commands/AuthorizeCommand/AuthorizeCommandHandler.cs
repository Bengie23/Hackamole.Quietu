using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.Domain.Events;
using Hackamole.Quietu.SharedKernel.Events;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using Microsoft.Extensions.Configuration;

namespace hackamole.quietu.domain.Commands;

public class AuthorizeCommandHandler : ICommandHandler<AuthorizeCommand>
{
    private IServiceProvider serviceProvider;
    private IConfiguration configuration;

    public AuthorizeCommandHandler(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.configuration = configuration;
    }

    public void Handle(AuthorizeCommand command)
    {
        new EventsManager<AuthorizedEvent>(configuration, serviceProvider).Raise(new AuthorizedEvent
        {
            Authorized = true,
            PrincipalId = command.PrincipalId,
            ProductCode = command.ProductCode
        });
    }
}