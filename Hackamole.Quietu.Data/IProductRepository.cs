using System;
using Hackamole.Quietu.Domain.Entities;

namespace Hackamole.Quietu.Data
{
    public interface IProductRepository
    {
        ProductCode GetByProductByCode(string productCode);
    }
}

