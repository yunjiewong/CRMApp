using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Antra.CRMApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountServiceAsync _accountServiceAsync;
        private readonly IConfiguration _configuration;

        public AccountController(IAccountServiceAsync accountServiceAsync, IConfiguration configuration)
        {
            _accountServiceAsync = accountServiceAsync;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel model)
        {
            var result = await _accountServiceAsync.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _accountServiceAsync.SignInAsync(model);
            if (!result.Succeeded)
                return Unauthorized();

            var authClaims = new List<Claim> {
            new Claim(ClaimTypes.Name, model.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiene"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                ); ;

            var h = new { jwt = new JwtSecurityTokenHandler().WriteToken(token) };
            return Ok(h);

        }
    }
}

