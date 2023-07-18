using Hackamole.Quietu.Domain.Exceptions;
using hackamole.quietu.SharedKernel.Interfaces.Commands;
using Microsoft.AspNetCore.Http;

namespace Hackamole.Quietu.Domain.Commands.AuthorizeCommand
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected abstract void Handle(TCommand command);

        protected abstract bool IsSecureCommand(TCommand command);

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

