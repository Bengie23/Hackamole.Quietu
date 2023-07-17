using System;
namespace Hackamole.Quietu.Api.Models
{
    public class AuthenticateResponse
    {
        public string Token { get; set; }


        public AuthenticateResponse(string token)
        {
            Token = token;
        }
    }
}

