using System;
using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Entities.Projections;

namespace Hackamole.Quietu.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByPrincipalId(int id);
        List<ProductCodeUsageCount> GetProductCodeUsageProjections();
        List<PrincipalAttemptedProduct> GetProductAttemptedProductProjections(string productCode);
    }
}

