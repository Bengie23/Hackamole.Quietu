using System;
namespace Hackamole.Quietu.SharedKernel.Events.Interfaces
{
	public interface IEventsManager<T> where T : IDomainEvent
	{
		void Raise(T raisedEvent);
	}
}

