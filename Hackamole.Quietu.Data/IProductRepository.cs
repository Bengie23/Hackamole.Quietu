using System;
namespace Hackamole.Quietu.Data
{
    public interface IProductRepository
    {
        string GetByProductByCode(string productCode);
    }
}

