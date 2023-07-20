using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.Domain.Commands.AuthorizeCommand;
using Hackamole.Quietu.Domain.Events;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events;
using Hackamole.Quietu.SharedKernel.Events.Interfaces;
using Microsoft.Extensions.Configuration;

namespace hackamole.quietu.domain.Commands;

public class AuthorizeCommandHandler : BaseCommandHandler<AuthorizeCommand>, ICommandHandler<AuthorizeCommand>
{
    private IServiceProvider serviceProvider;
    private IConfiguration configuration;
    private readonly IProductRepository productRepository;
    private readonly IAuthenticatedPrincipalProvider authenticatedPrincipalProvider;
    private readonly IEventsManager<AuthorizedEvent> eventsManager;

    public AuthorizeCommandHandler( IConfiguration configuration,
                                    IServiceProvider serviceProvider,
                                    IProductRepository productRepository,
                                    IAuthenticatedPrincipalProvider authenticatedPrincipalProvider,
                                    IEventsManager<AuthorizedEvent> eventsManager)
    {
        this.serviceProvider = serviceProvider;
        this.configuration = configuration;
        this.productRepository = productRepository;
        this.authenticatedPrincipalProvider = authenticatedPrincipalProvider;
        this.eventsManager = eventsManager;
    }

    public override void Handle(AuthorizeCommand command)
    {
        bool authorized = productRepository.GetProductsByPrincipalId(command.PrincipalId).Any(product => product.Code == command.ProductCode);
        
        eventsManager.Raise(new AuthorizedEvent
        {
            Authorized = authorized,
            PrincipalId = command.PrincipalId.ToString(),
            ProductCode = command.ProductCode
        });
    }

    public override bool IsSecureCommand(AuthorizeCommand command)
    {
        return command.PrincipalId == authenticatedPrincipalProvider.GetAuthenticatedPrincipalId();
    }
}