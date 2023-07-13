using System;
using System.ComponentModel.DataAnnotations;

namespace Hackamole.Quietu.Api.Models
{
	public class AuthenticationRequest
	{
		[Required]
		public string KeyId { get; set; }

		[Required]
		public string Secret { get; set; }
	}
}

