using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Hackamole.Quietu.Domain.Commands.AuthorizeCommand;
using Hackamole.Quietu.Domain.Events;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Events;
using Microsoft.Extensions.Configuration;

namespace hackamole.quietu.domain.Commands;

public class AuthorizeCommandHandler : BaseCommandHandler<AuthorizeCommand>, ICommandHandler<AuthorizeCommand>
{
    private IServiceProvider serviceProvider;
    private IConfiguration configuration;
    private readonly IProductRepository productRepository;

    public AuthorizeCommandHandler( IConfiguration configuration,
                                    IServiceProvider serviceProvider,
                                    IProductRepository productRepository)
    {
        this.serviceProvider = serviceProvider;
        this.configuration = configuration;
        this.productRepository = productRepository;
    }

    public override void Handle(AuthorizeCommand command)
    {
        new EventsManager<AuthorizedEvent>(configuration, serviceProvider).Raise(new AuthorizedEvent
        {
            Authorized = true,
            PrincipalId = command.PrincipalId.ToString(),
            ProductCode = command.ProductCode
        });
    }

    public override bool IsSecureCommand(AuthorizeCommand command)
    {
        return productRepository.GetProductsByPrincipalId(command.PrincipalId).Any(product => product.Code == command.ProductCode);
    }
}