using System;
using Hackamole.Quietu.Domain.Entities;

namespace Hackamole.Quietu.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsByPrincipalId(int id);
        void IncreaseProductUsageCount(string productCode);
    }
}

