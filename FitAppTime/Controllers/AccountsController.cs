using FitAppModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FitAppTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<FitAppUser> _userManager;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<FitAppUser> userManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");

        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterExpUser([FromBody] UserRegistrationDto userRegistration)
        {
            if (userRegistration == null || !ModelState.IsValid)
                return BadRequest();
            var user = new FitAppUser 
            {
                UserName = userRegistration.Email, 
                Email = userRegistration.Email,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                DateAdded = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            //await _userManager.AddToRoleAsync(user, "User");

            return Ok($"{user.FirstName} {user.LastName} has been registered");//String interpolation is similar to Javascript
        }

      

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginAuthenticationDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized(new LoginResponseDto { IsLoginSuccessful = false, ErrMessage = "Invalid Authentication" });

            else 
            {
                var signingCredentials = GetSigningCredentials();
                var userClaims = await GetClaims(user);
                var tokeOptions = GenerateTokenOptions(signingCredentials, userClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);



                return Ok(new LoginResponseDto { IsLoginSuccessful = true, Token = tokenString });
            }
            
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        private async Task<List<Claim>> GetClaims(FitAppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)

            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

            return tokOptions;
        }

    }
}
