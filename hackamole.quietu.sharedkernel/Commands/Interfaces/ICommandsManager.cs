using hackamole.quietu.SharedKernel.Commands.Interfaces;

namespace Hackamole.Quietu.SharedKernel.Commands.Interfaces
{
	public interface ICommandsManager<T> where T : ICommand
	{
		void Route(T command);
	}
}

