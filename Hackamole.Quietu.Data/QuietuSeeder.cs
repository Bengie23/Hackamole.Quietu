using Hackamole.Quietu.Domain.Entities;

namespace Hackamole.Quietu.Data
{
    public  class QuietuSeeder
    {
        private QuietuDbContext DbContext;

        public QuietuSeeder(QuietuDbContext dbContext) 
        {
            this.DbContext = dbContext;
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        }

        public void Seed()
        {
            var products = new List<Product>()
            {
                new Product { Code = "ProductA" },
                new Product { Code = "ProductB" },
                new Product { Code = "ProductC" },
                new Product { Code = "ProductD" },
                new Product { Code = "PRODUCT_GROUP_HUB_APPOINTMENTS_FOR_PARTNERS"}
            };
            DbContext.Principals.Add(new Domain.Entities.Principal()
            {
                KeyId = "a9b85d2e-6049-4558-9d36-447f3f7710b8",
                Secret = "51bcabef6ad7f9d117dabaf21969ab42446286a4fa30dc204bd4f27ff9f43f85",
                Name= "Portal",
                Products = products
            });

            DbContext.SaveChanges();
        }
    }
}
