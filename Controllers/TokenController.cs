using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace mvct.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
      
                  var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, "alice"),
                        new Claim(JwtRegisteredClaimNames.Jti, 1.ToString()),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("very_long_very_secret_secret"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(claims:claims,signingCredentials: creds);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
          
        }
    }
}