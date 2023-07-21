namespace hackamole.quietu.SharedKernel.Commands.Interfaces;

public interface ICommandHandler<TCommand> where TCommand: ICommand {

    void TryHandle(TCommand command);

}