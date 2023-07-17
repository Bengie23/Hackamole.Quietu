using System;
namespace Hackamole.Quietu.Api.Data
{
	public interface IPrincipalRepository
	{
		string GetPrincipalByKeyId(string keyId);

		bool SecretMatchesForPrincipalId(int principalId, string secret);
	}
}

