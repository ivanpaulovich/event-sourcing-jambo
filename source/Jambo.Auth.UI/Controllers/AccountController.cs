using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Jambo.Auth.Application.Commands;

namespace Jambo.Auth.UI
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly Config config;

        public AccountController(Config config)
        {
            this.config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Token([FromBody] LoginCommand loginCommand)
        {
            //
            // TODO: Implementar uma verificação 
            // se loginCommand.Username e loginCommand.Password são válidos.
            //

            var token = GetJwtSecurityToken(loginCommand.Username);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        private JwtSecurityToken GetJwtSecurityToken(string user)
        {
            return new JwtSecurityToken(
                config.Issuer,
                config.Issuer,
                GetTokenClaims(user),
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey)),
                    SecurityAlgorithms.HmacSha256)
            );
        }

        private static IEnumerable<Claim> GetTokenClaims(string user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user)
            };
        }
    }
}
