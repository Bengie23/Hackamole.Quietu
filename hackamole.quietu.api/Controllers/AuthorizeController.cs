
using hackamole.quietu.api.Authorization;
using hackamole.quietu.domain.Commands;
using hackamole.quietu.domain.DTOs;
using hackamole.quietu.SharedKernel.Commands;
using Hackamole.Quietu.Domain.Exceptions;
using Hackamole.Quietu.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorizeController: ControllerBase {

    private IServiceProvider serviceProvider;
    private CommandManager<AuthorizeCommand> authorizeCommandManager;
    private readonly IAuthenticatedPrincipalProvider authenticatedPrincipalProvider;

    public AuthorizeController(IServiceProvider serviceProvider, IAuthenticatedPrincipalProvider authenticatedPrincipalProvider)
    {
        this.serviceProvider = serviceProvider;
        this.authorizeCommandManager = new CommandManager<AuthorizeCommand>(serviceProvider);
        this.authenticatedPrincipalProvider = authenticatedPrincipalProvider;
    }

    [HttpPost]
    public IActionResult Post(AuthorizeDTO request)
    {
        var command = new AuthorizeCommand();
        command.CommandDate = DateTime.Now;
        command.ProductCode = request.ProductCode;
        //command.PrincipalId = authenticatedPrincipalProvider.GetAuthenticatedPrincipalId();
        try
        {
            authorizeCommandManager.Route(command);
        }
        catch (UnauthorizedAccessToProductException ex)
        {
            return Unauthorized(ex.Message);
        }

        return Ok("");
    }

}