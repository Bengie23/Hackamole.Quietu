using System;
namespace Hackamole.Quietu.Domain.DTOs
{
	public class AuthenticateResponseDTO
	{
        public string Token { get; set; }


        public AuthenticateResponseDTO(string token)
        {
            Token = token;
        }
    }
}

