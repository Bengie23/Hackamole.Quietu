using System;
using Hackamole.Quietu.Domain.DTOs;
using Hackamole.Quietu.Domain.Entities.Projections;

namespace Hackamole.Quietu.Domain.Transformations
{
	public static class ProductTransformationExtensions
	{
		public static List<ProductDetailConsumptionDTO> ToDTO(this List<PrincipalAttemptedProduct> principalAttemptedProduct)
		{
			var result = new List<ProductDetailConsumptionDTO>();
			foreach (var item in principalAttemptedProduct)
			{
				result.Add(item.ToDTO());
			}
			return result;
		}

		public static ProductDetailConsumptionDTO ToDTO(this PrincipalAttemptedProduct principalAttemptedProduct)
		{
			return new ProductDetailConsumptionDTO()
			{
				Date = principalAttemptedProduct.AuthorizedAt,
				Status = principalAttemptedProduct.Authorized ? "SUCCESS" : "FAILED",
				Identity = new IdentityDTO()
				{
					Name = principalAttemptedProduct.Principal.Name,
					Type = principalAttemptedProduct.Principal.Type.ToString()
                }
			};
		}

		public static List<ProductConsumptionDTO> ToDTO(this List<ProductCodeUsageCount> productCodeUsages)
		{
			var result = new List<ProductConsumptionDTO>();
			foreach (var item in productCodeUsages)
			{
				result.Add(item.ToDTO());
			}
			return result;
		}

		public static ProductConsumptionDTO ToDTO(this ProductCodeUsageCount productCodeUsage)
		{
			return new ProductConsumptionDTO
			{
				ProductCode = productCodeUsage.ProductCode,
				Usage = new ProductCountDTO
				{
					Success = productCodeUsage.Success,
					Failed = productCodeUsage.Failed
				}
			};
		}
	}
}

