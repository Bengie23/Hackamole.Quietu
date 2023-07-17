using System;
using Hackamole.Quietu.Domain.Entities;
namespace Hackamole.Quietu.Data
{
    public interface IPrincipalRepository
    {
        Principal GetPrincipalByKeyId(string keyId);

        bool SecretMatchesForPrincipalId(int principalId, string secret);
    }
}

