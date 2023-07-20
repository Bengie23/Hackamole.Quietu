using System.ComponentModel.DataAnnotations;

namespace Hackamole.Quietu.Domain.Entities.Projections
{
	public class ProductCodeUsageCount
	{
		[Key]
		public string ProductCode { get; set; }
		public int Success { get; set; }
		public int Failed { get; set; }

	}
}