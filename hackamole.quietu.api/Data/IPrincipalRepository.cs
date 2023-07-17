using System;
using Hackamole.Quietu.Domain.Entities;

namespace Hackamole.Quietu.Api.Data
{
	public interface IPrincipalRepository
	{
		Principal GetPrincipalById(int principalId);

		bool SecretMatchesForPrincipalId(int principalId, string secret);
	}
}

