using Hackamole.Quietu.Domain.Entities;

namespace Hackamole.Quietu.Data
{
    public interface IProductRepository
    {
        List<Product> GetProductsByPrincipalId(int id);
    }
}

