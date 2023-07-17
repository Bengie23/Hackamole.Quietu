
using hackamole.quietu.domain.Commands;
using hackamole.quietu.domain.DTOs;
using hackamole.quietu.SharedKernel.Commands;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AuthorizeController: ControllerBase {

    private IServiceProvider serviceProvider;
    private CommandManager<AuthorizeCommand> authorizeCommandManager;

    public AuthorizeController(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.authorizeCommandManager = new CommandManager<AuthorizeCommand>(serviceProvider);
    }

    [HttpPost]
    [Route("Api/[Controller]/Authorize")]
    public IActionResult Post(AuthorizeDTO request)
    {
        var command = new AuthorizeCommand();
        command.CommandDate = DateTime.Now;
        command.ProductCode = request.ProductCode;

        authorizeCommandManager.Route(command);

        return Ok("");
    }

}