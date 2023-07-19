using System;
using Hackamole.Quietu.Domain.DTOs;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Transformations;

namespace Hackamole.Quietu.Domain.Querys
{
	public class ProductDetailConsumptionQuery
	{
        private readonly IProductRepository repo;

        public ProductDetailConsumptionQuery(IProductRepository productRepository)
		{
			this.repo = productRepository;

			ArgumentNullException.ThrowIfNull(productRepository, nameof(productRepository));
		}

        public List<ProductDetailConsumptionDTO> ExecuteQuery(string productCode)
        {
            var data = repo.GetProductAttemptedProductProjections(productCode);
            return data.ToDTO();
        }
	}
}

