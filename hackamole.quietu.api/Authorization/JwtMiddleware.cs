using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Interfaces;

namespace hackamole.quietu.api.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IPrincipalRepository principalRepository, IJWTManager manager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var principalId = manager.ValidateJwtToken(token);
            if (principalId != null)
            {
                var principal = principalRepository.GetPrincipalById(principalId.Value);
                if (principal is not null)
                {
                    context.Items["PrincipalId"] = principalId;
                }
            }

            await _next(context);
        }
    }
}

