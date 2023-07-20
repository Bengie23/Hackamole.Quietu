using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.DTOs;
using Hackamole.Quietu.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackamole.Quietu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTManager jwtManager;
        private readonly IPrincipalRepository PrincipalRepository;

        public AuthenticateController(IJWTManager jWTManager, IPrincipalRepository principalRepository)
        {
            this.jwtManager = jWTManager;
            this.PrincipalRepository = principalRepository;

            ArgumentNullException.ThrowIfNull(principalRepository,nameof(principalRepository));
            ArgumentNullException.ThrowIfNull(jWTManager, nameof(jwtManager));
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequestDTO model)
        {
            if (PrincipalRepository.SecretMatchesForKeyId(model.ApiKey, model.Secret, out var principal))
            {
                return Ok(new AuthenticateResponseDTO(jwtManager.GenerateJwtToken(principal.Id)));
            }

            return Unauthorized();
        }
    }
}