
using hackamole.quietu.api.Authorization;
using hackamole.quietu.domain.Commands;
using hackamole.quietu.domain.DTOs;
using hackamole.quietu.SharedKernel.Commands;
using Hackamole.Quietu.Domain.Exceptions;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.SharedKernel.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[AuthorizeForQuietu]
[Route("api/[controller]")]
public class AuthorizeController: ControllerBase {

    private ICommandsManager<AuthorizeCommand> authorizeCommandsManager;
    private readonly IAuthenticatedPrincipalProvider authenticatedPrincipalProvider;

    public AuthorizeController(IAuthenticatedPrincipalProvider authenticatedPrincipalProvider, ICommandsManager<AuthorizeCommand> authorizeCommandsManager)
    {
        this.authorizeCommandsManager = authorizeCommandsManager;
        this.authenticatedPrincipalProvider = authenticatedPrincipalProvider;

        ArgumentNullException.ThrowIfNull(authorizeCommandsManager, nameof(authorizeCommandsManager));
        ArgumentNullException.ThrowIfNull(authenticatedPrincipalProvider, nameof(authenticatedPrincipalProvider));
    }

    [HttpPost]
    public IActionResult Post(AuthorizeDTO request)
    {
        var command = new AuthorizeCommand();
        command.CommandDate = DateTime.Now;
        command.ProductCode = request.ProductCode;
        command.PrincipalId = authenticatedPrincipalProvider.GetAuthenticatedPrincipalId();
        try
        {
            authorizeCommandsManager.Route(command);
        }
        catch (UnauthorizedAccessToProductException ex)
        {
            return Unauthorized(ex.Message);
        }

        return Ok("");
    }

}