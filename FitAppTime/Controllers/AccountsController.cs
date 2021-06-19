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
            { 
                return BadRequest(new RegistrationResponseDto { IsSuccessfulRegistration = false, ResponseMessage = "Model State invalid"});          
            }
            else 
            {
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
                    return BadRequest(new RegistrationResponseDto 
                    {
                        IsSuccessfulRegistration = false, 
                        Errors = errors });
                }
                else 
                {
                    /*Whatever role is entered as the second argument below needs to be created by you first
                    in order for this to work*/
                    if(userRegistration.FirstName == "Sean" && userRegistration.LastName == "Joseph")
                    {
                        await _userManager.AddToRoleAsync(user, "Administrator");
                    }
                    if (userRegistration.IsAthlete == true) 
                    {
                        await _userManager.AddToRoleAsync(user, "Athlete");
                    }
                    else 
                    {
                        await _userManager.AddToRoleAsync(user, "Coach");

                    }


                    return Ok(new RegistrationResponseDto 
                    {
                        IsSuccessfulRegistration = true,
                        ResponseMessage = $"Success!! {user.FirstName} {user.LastName} has been registered. " 
                    });

                    /*The commented out below line(after this comment) was not sufficient because it didn't return 
                     JSON. This lead to a successful operation(a 200 response) but an error after the fact in the 
                     React client since it was expecting Json to be return*/

                    //return Ok($"{user.FirstName} {user.LastName} has been registered");//String interpolation is similar-ish to Javascript              
                }
            
            }
        }

      

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginAuthenticationDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized(new LoginResponseDto { IsLoginSuccessful = false, ResponseMessage = "Invalid Authentication" });

            else 
            {
                var signingCredentials = GetSigningCredentials();
                var userClaims = await GetClaims(user);
                var tokeOptions = GenerateTokenOptions(signingCredentials, userClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var roles = await _userManager.GetRolesAsync(user);


                return Ok(new LoginResponseDto 
                { 
                    IsLoginSuccessful = true,
                    Token = tokenString,
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = roles,
                    Email = user.Email,
                    ResponseMessage = "User Credentials Verified!",
                });
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
