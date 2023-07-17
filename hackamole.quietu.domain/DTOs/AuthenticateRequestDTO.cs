using System;
using System.ComponentModel.DataAnnotations;
using Hackamole.Quietu.Domain.Options;

namespace Hackamole.Quietu.Domain.DTOs
{
    public class AuthenticateRequestDTO
    {
        [Required]
        public string KeyId { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}