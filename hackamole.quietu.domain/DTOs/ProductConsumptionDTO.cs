using System;
namespace Hackamole.Quietu.Domain.DTOs
{
	public class ProductConsumptionDTO
	{
		public string ProductCode { get; set; }
		public ProductCountDTO Usage { get; set; }
	}
}

