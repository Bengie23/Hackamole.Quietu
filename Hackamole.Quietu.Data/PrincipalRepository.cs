using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Interfaces;

namespace Hackamole.Quietu.Data
{
    public class PrincipalRepository : IPrincipalRepository
    {
        private readonly QuietuDbContext DbContext;

        public PrincipalRepository(QuietuDbContext dbContext)
        {
            this.DbContext = dbContext;
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        }
        public Principal GetPrincipalById(int principalId)
        {
            return DbContext.Principals.FirstOrDefault(Principal => Principal.Id == principalId);
        }

        public bool SecretMatchesForKeyId(string keyId, string secret, out Principal principal)
        {
            principal = DbContext.Principals.FirstOrDefault(Principal => Principal.KeyId == keyId);
            var storedSecret = principal?.Secret;
            return secret.Equals(storedSecret,StringComparison.OrdinalIgnoreCase);
        }
    }
}
