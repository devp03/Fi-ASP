using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginModel login)
        {
            var userIsValid = validUser(login);
            if (!userIsValid)
            {
                return Unauthorized();
                
            }
            var token = GenerateJWT(login.UserName);
            return Ok();

        }

        private object GenerateJWT(string userName) { 
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, userName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Name, "Lucas"),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(320),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);



        }

        private bool validUser(LoginModel login)
        {
            return login.UserName == "root" && login.Password == "root";
        }

        public class LoginModel { 
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
