using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string key =
            "ThisIsASecretKeyForJwtTokenDontShare";

        [HttpPost("login")]
        public IActionResult Login()
        {
            var token = GenerateToken();

            return Ok(token);
        }

        private string GenerateToken()
        {
            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(key));

            var credentials =
                new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.Name,
                    "admin")
            };

            var token =
                new JwtSecurityToken(
                    claims: claims,
                    expires:
                        DateTime.Now.AddMinutes(30),
                    signingCredentials:
                        credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}