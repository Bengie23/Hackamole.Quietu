using Hackamole.Quietu.Domain.Exceptions;
using hackamole.quietu.SharedKernel.Commands.Interfaces;

namespace Hackamole.Quietu.Domain.Commands.AuthorizeCommand
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public abstract void Handle(TCommand command);

        public abstract bool IsSecureCommand(TCommand command);

        public void TryHandle(TCommand command)
        {
            if (!this.IsSecureCommand(command))
            {
                throw new UnauthorizedAccessToProductException();
            }

            this.Handle(command);
        }
    }
}

