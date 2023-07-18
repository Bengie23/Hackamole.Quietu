using System;
using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Api.Data;

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
            var userId = manager.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = principalRepository.GetPrincipalById(userId.Value);
            }

            await _next(context);
        }
    }
}

