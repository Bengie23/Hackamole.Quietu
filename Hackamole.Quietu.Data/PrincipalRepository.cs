using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hackamole.Quietu.Data
{
    public class PrincipalRepository : IPrincipalRepository
    {
        private readonly QuietuDbContext DbContext;

        public PrincipalRepository(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            this.DbContext = scope.ServiceProvider.GetService<QuietuDbContext>();
            ArgumentNullException.ThrowIfNull(DbContext, nameof(DbContext));
        }

        public Principal GetPrincipalById(int principalId)
        {
            return DbContext.Principals.FirstOrDefault(Principal => Principal.Id == principalId);
        }

        public Task RegisterPrincipalAttemptToAccessProduct(int principalId, string productCode, bool authorized)
        {
            DbContext.PrincipalAttemptedProducts.Add(new Domain.Entities.Projections.PrincipalAttemptedProduct
            {
                Authorized = authorized,
                ProductCode = productCode,
                PrincipalId = principalId,
                AuthorizedAt = DateTime.Now
            });

            return DbContext.SaveChangesAsync();
        }

        public bool SecretMatchesForKeyId(string keyId, string secret, out Principal principal)
        {
            principal = DbContext.Principals.FirstOrDefault(Principal => Principal.KeyId == keyId);
            var storedSecret = principal?.Secret;
            return secret.Equals(storedSecret,StringComparison.OrdinalIgnoreCase);
        }
    }
}
