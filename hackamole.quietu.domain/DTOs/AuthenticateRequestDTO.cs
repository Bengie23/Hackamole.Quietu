using System;
using System.ComponentModel.DataAnnotations;
using Hackamole.Quietu.Domain.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hackamole.Quietu.Domain.DTOs
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AuthenticateRequestDTO
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [Required]
        public string Secret { get; set; }
    }
}