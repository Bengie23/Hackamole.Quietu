using System;
using Hackamole.Quietu.Api.Authorization;
using Hackamole.Quietu.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackamole.Quietu.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTManager jwtManager;

        public AuthenticateController(IJWTManager jWTManager)
        {
            this.jwtManager = jWTManager;

            ArgumentNullException.ThrowIfNull(jWTManager, nameof(jwtManager));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequestDTO model)
        {


            //var response = _userService.Authenticate(model);

            //if (response == null)
            //    return BadRequest(new { message = "Username or password is incorrect" });

            var principalId = 1;
            return Ok(new AuthenticateResponseDTO(jwtManager.GenerateJwtToken(principalId)));
        }
    }
}