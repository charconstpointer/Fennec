using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fennec.Api.Controllers
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _key;

        public AuthController(IConfiguration configuration)
        {
            _key = configuration["Key"];
        }

        [HttpPost]
        public async Task<IActionResult> Login(Credentials credentials)
        {
            if (credentials.Username != "foo" || credentials.Password != "bar") return BadRequest();
            {
                var token = Token(credentials.Username);
                return Ok(token);
            }

            string Token(string username)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "fennec",
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1000),
                    SigningCredentials =
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)),
                            SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var wt = tokenHandler.WriteToken(token);
                return wt;
            }
        }
    }
}