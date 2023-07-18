using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Data;

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
                // attach user to context on successful jwt validation
                context.Items["PrincipalId"] = principalRepository.GetPrincipalById(principalId.Value);
            }

            await _next(context);
        }
    }
}

