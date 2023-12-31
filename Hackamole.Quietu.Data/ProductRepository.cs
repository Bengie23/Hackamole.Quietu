﻿using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Entities.Projections;
using Hackamole.Quietu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly QuietuDbContext dbContext;

        public ProductRepository(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            this.dbContext = scope.ServiceProvider.GetService<QuietuDbContext>();

            ArgumentNullException.ThrowIfNull(dbContext,nameof(dbContext));
        }

        public List<PrincipalAttemptedProduct> GetProductAttemptedProductProjections(string productCode)
        {
            var data = dbContext.PrincipalAttemptedProducts.Where(attempts => attempts.ProductCode == productCode).ToList();
            data.ForEach(x => x.Principal = dbContext.Principals.FirstOrDefault(principal => principal.Id == x.PrincipalId));
            return data;
        }

        public List<ProductCodeUsageCount> GetProductCodeUsageProjections()
        {
            return dbContext.ProductCodeUsages.ToList();
        }

        public List<Product> GetProductsByPrincipalId(int id)
        {
            return dbContext.Principals.Include(principal => principal.Products).FirstOrDefault(principal => principal.Id == id)?.Products;
        }

        public Task RegisterProductCodeUsage(string productCode, bool authorized)
        {
            var data = dbContext.ProductCodeUsages.Where(product => product.ProductCode == productCode);
            if (data.Any())
            {
                var existing = data.First();
                if (authorized)
                {
                    existing.Success += 1;
                }
                else
                {
                    existing.Success -= 1;
                }
            }

            if (!data.Any())
            {
                dbContext.ProductCodeUsages.Add(new ProductCodeUsageCount
                {
                    Failed = !authorized ? 1:0,
                    Success = authorized ? 1:0,
                    ProductCode = productCode
                });
            }
            return dbContext.SaveChangesAsync();
        }
    }
}
