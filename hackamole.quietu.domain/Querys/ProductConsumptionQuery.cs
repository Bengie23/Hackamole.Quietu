using System;
using Hackamole.Quietu.Domain.DTOs;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Transformations;

namespace Hackamole.Quietu.Domain.Querys
{
	public class ProductConsumptionQuery
	{
        private readonly IProductRepository repo;

        public ProductConsumptionQuery(IProductRepository productRepository)
		{
			this.repo = productRepository;

			ArgumentNullException.ThrowIfNull(productRepository, nameof(productRepository));
		}


        public List<ProductConsumptionDTO> ExecuteQuery()
        {
            var data = repo.GetProductCodeUsageProjections();
            return data.ToDTO();
        }
    }
}

