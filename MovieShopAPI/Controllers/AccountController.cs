using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestModel model)
        {
            var user = await _userService.ValidateUser(model.Email, model.Password);

            if (user == null)
            {
                // invalid un/password
                return Unauthorized();
            }
            // valid un/password
            // create JWT and send it to clint(Angular), add claim info into token
            return Ok(new { token = GenerateJWT(user) });
        }

        private string GenerateJWT(UserLoginResponseModel user)
        {
            // 

            var claims = new List<Claim> {

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),            
            };

            // add the required claims to identity object
            var identityCLaims = new ClaimsIdentity();
            identityCLaims.AddClaims(claims);


            // Microsoft.IdentityModel.Tokens;
            // get the secret key for signing the token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretKey"]));

            // sepecify the algorithm to sign the token
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<int>("ExpirationHours"));


            // Creating the token System.IdentityModel.Tokens.Jwt

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityCLaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["Issuer"],
                Audience = _configuration["Audience"]
            };


            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(encodedJwt);

        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserDetails(id);
            return Ok(user);
        }
    }
}