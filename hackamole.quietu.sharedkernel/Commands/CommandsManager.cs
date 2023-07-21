using hackamole.quietu.SharedKernel.Commands.Interfaces;
using Hackamole.Quietu.SharedKernel.Commands.Interfaces;

namespace hackamole.quietu.SharedKernel.Commands;

public class CommandsManager<T> : ICommandsManager<T> where T: ICommand
{
    private IServiceProvider serviceProvider;

    public CommandsManager(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public void Route(T command)
    {
        var type = typeof(ICommandHandler<>);   
        Type[] typeArgs = { command.GetType() };
        Type factoryType = type.MakeGenericType(typeArgs);

        if (serviceProvider != null)
        {
            dynamic handler = serviceProvider.GetService(factoryType);
            handler.Handle(command);
        }
    }
}