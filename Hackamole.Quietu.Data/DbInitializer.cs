namespace Hackamole.Quietu.Data
{
    public class DbInitializer
    {
        private readonly QuietuDbContext DbContext;
        private readonly QuietuSeeder DbSeeder;

        public DbInitializer(QuietuDbContext dbContext, QuietuSeeder dbSeeder)
        {
            ArgumentNullException.ThrowIfNull(dbContext);
            ArgumentNullException.ThrowIfNull(dbSeeder);

            this.DbContext = dbContext;
            this.DbSeeder = dbSeeder;
        }

        public void Run()
        {
            //DbContext.Database.EnsureDeleted();
            //DbContext.Database.EnsureCreated();

            //DbSeeder.Seed();
        }
    }
}
