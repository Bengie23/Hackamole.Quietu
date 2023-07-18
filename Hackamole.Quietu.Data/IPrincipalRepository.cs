using System;
using Hackamole.Quietu.Domain.Entities;
namespace Hackamole.Quietu.Data
{
    public interface IPrincipalRepository
    {

        Principal GetPrincipalById(int PrincipalId);

        bool SecretMatchesForKeyId(string keyId, string secret, out Principal principal);
    }
}

