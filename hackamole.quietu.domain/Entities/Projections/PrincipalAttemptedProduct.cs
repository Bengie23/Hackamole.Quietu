using System;
namespace Hackamole.Quietu.Domain.Entities.Projections
{
	public class PrincipalAttemptedProduct
	{
		public int PrincipalId { get; set; }
		public string ProductCode { get; set; }
		public bool Authorized { get; set; }
		public DateTime AuthorizedAt { get; set; }
	}
}

