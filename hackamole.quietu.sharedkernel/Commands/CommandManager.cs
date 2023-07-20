using hackamole.quietu.SharedKernel.Interfaces.Commands;

namespace hackamole.quietu.SharedKernel.Commands;

public class CommandManager<T> where T: ICommand
{
    private IServiceProvider serviceProvider;

    public CommandManager(IServiceProvider serviceProvider)
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