using Hackamole.Quietu.Data;
using Hackamole.Quietu.Domain.Entities;
using Hackamole.Quietu.Domain.Interfaces;
using Hackamole.Quietu.Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hackamole.Quietu.Api.Authorization
{
	public class JWTManager : IJWTManager
	{
        private readonly JWTManagerOptions options;
        private readonly IProductRepository productRepository;

        public JWTManager(JWTManagerOptions options, IProductRepository productRepository)
        {
            this.options = options;
            this.productRepository = productRepository;

            ArgumentNullException.ThrowIfNull(productRepository,nameof(productRepository));
            ArgumentNullException.ThrowIfNull(options, nameof(options));
        }

        public string GenerateJwtToken(int principalId)
        {
            // generate token that is valid for 7 days
            var product_codes = productRepository.GetProductsByPrincipalId(principalId).Select(product => product.Code).Take(10).ToList();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("PrincipalId", principalId.ToString()), new Claim("ProductCodes", String.Join(",", product_codes.ToArray() as object[])) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? ValidateJwtToken(string? token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.Secret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var PrincipalId = int.Parse(jwtToken.Claims.First(x => x.Type == "PrincipalId").Value);

                // return user id from JWT token if validation successful
                return PrincipalId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}

