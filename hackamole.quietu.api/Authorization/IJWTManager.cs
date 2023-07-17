using System;
namespace Hackamole.Quietu.Api.Authorization
{
	public interface IJWTManager
	{
        public string GenerateJwtToken(int principalId);
        public int? ValidateJwtToken(string? token);
    }
}

