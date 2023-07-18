using System;
namespace Hackamole.Quietu.Domain.Exceptions
{
	public class UnauthorizedAccessToProductException : UnauthorizedAccessException
	{
		public UnauthorizedAccessToProductException() : base("Access Rejected: The given principal Id does not have access to the given product.")
		{
		}
	}
}

