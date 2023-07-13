namespace hackamole.quietu.SharedKernel.Interfaces.Commands;

public interface ICommandHandler<TCommand> where TCommand: ICommand {

  void Handle(TCommand command);

    List<Type> CollectEvents();

}