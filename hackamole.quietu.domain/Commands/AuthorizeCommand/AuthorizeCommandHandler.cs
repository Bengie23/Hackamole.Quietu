using hackamole.quietu.SharedKernel.Interfaces.Commands;

namespace hackamole.quietu.domain.Commands;

public class AuthorizeCommandHandler : ICommandHandler<AuthorizeCommand>
{
    public void Handle(AuthorizeCommand command)
    {
        Console.WriteLine("CommandExecuted");
    }
}