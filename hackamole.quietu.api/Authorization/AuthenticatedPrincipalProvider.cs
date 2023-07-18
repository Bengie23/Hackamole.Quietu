using System;
using Hackamole.Quietu.Domain.Interfaces;

namespace hackamole.quietu.api.Authorization
{
	public class AuthenticatedPrincipalProvider : IAuthenticatedPrincipalProvider
	{
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthenticatedPrincipalProvider(IHttpContextAccessor httpContextAccessor)
		{
            this.httpContextAccessor = httpContextAccessor;

            ArgumentNullException.ThrowIfNull(httpContextAccessor, nameof(httpContextAccessor));
		}

        public int GetAuthenticatedPrincipalId()
        {
            return (int)httpContextAccessor.HttpContext.Items["PrincipalId"];
            
        }
    }
}

