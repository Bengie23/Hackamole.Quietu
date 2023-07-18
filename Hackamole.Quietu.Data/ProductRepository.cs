using Hackamole.Quietu.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackamole.Quietu.Data
{
    internal class ProductRepository : IProductRepository
    {
        private readonly QuietuDbContext dbContext;

        public ProductRepository(QuietuDbContext dbContext)
        {
            this.dbContext = dbContext;

            ArgumentNullException.ThrowIfNull(dbContext,nameof(dbContext));
        }
        public List<Product> GetProductsByPrincipalId(int id)
        {
            return dbContext.Principals.Include(principal => principal.Products).FirstOrDefault(principal => principal.Id == id)?.Products;
        }
    }
}
