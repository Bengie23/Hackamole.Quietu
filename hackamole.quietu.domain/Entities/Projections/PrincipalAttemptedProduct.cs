using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackamole.Quietu.Domain.Entities.Projections
{
	public class PrincipalAttemptedProduct
	{
		public int Id { get; set; }
		public int PrincipalId { get; set; }
		public string ProductCode { get; set; }
		public bool Authorized { get; set; }
		public DateTime AuthorizedAt { get; set; }
		[NotMapped]
		public Principal Principal { get; set; }
	}
}

