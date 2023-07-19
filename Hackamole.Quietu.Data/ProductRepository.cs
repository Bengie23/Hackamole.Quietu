using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Interfaces;
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

        public void IncreaseProductUsageCount(string productCode)
        {
            //var item = dbContext.IncreaseCounterNewTable.FirstOrDefault(pc => pc.ProductCode == productCode);
            //item.count += 1;
            //dbContext.SaveChanges();
        }
    }
}
