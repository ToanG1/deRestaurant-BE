using System;
using Microsoft.AspNetCore.Mvc;
using DeRestaurant.Models.DTO.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace DeRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
	{
        [HttpPost]
        public IActionResult login([FromBody] LoginRequest request)
        {
            if (!authenticateUser(request)) return Unauthorized();
            else
            {
                return Ok(new { token = GenerateJSONWebToken() });
            }
        }

        private bool authenticateUser(LoginRequest request)
        {
            if (request.username == "toandeptrai") return true;
            else return false;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is a sample secret key - please don't use in production environment.'"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, "Dinh Van Toan Admin"),
                new Claim(JwtRegisteredClaimNames.Email, "Toandeptrai@gmail.com"),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken("mytest.com",
              "mytest.com",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

