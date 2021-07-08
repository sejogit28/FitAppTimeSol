using FitAppDataStoreEF;
using FitAppModels;
using FitAppModels.AuthModels;
using FitAppModels.BaseModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FitAppDbContext _datFitBase;

        public AccountsController(UserManager<FitAppUser> userManager, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, FitAppDbContext fitDB) 
        {
            _userManager = userManager;
            _configuration = configuration;
            this._webHostEnvironment = webHostEnvironment;
            _jwtSettings = _configuration.GetSection("JwtSettings");
            _datFitBase = fitDB;
        }

        [HttpGet("allUsers")]
        public IActionResult GetAllIdentityUsers()
        {
            var usersQueryable = _userManager.Users;
            var usersList = usersQueryable.ToList();
            return Ok(new OperationResponse
            {
                OperationMessage = "Returning list of users",
                OperationSuccessful = true,
                ReturnedObject = usersList

            });
        }

        [HttpGet("getSingleUser/{singleUserName}")]
        public async Task<IActionResult> GetIdentityUser(string singleUserName)
        {
            var singleUser = await _userManager.FindByNameAsync(singleUserName);
            if (singleUser == null)
            {
                return NotFound(new OperationResponse
                {
                    OperationMessage = "User not found",
                    OperationSuccessful = false,

                });
            }
            else
            {
                return Ok(new OperationResponse
                {
                    OperationMessage = "Returning info for a single user",
                    OperationSuccessful = true,
                    ReturnedObject = singleUser

                });
            }

        }

        [HttpPut("updateUserPassword/{userName}")]
        public async Task<IActionResult> EditIdentityUserPassword([FromBody] ChangePassword changePassword, string userName)
        {
            var updatedUser = await _userManager.FindByNameAsync(userName);
            var passwordCheck = await _userManager.CheckPasswordAsync(updatedUser, changePassword.CurrentPassword);

            if (updatedUser == null)
            {
                return NotFound(new OperationResponse
                {
                    OperationMessage = $"User with Identiy Username: \"{userName}\" was not found",
                    OperationSuccessful = false,

                });
            }
            else if (passwordCheck != true)
            {
                return BadRequest(new OperationResponse
                {
                    OperationMessage = $"Value entered for \"current Password\" for user:" +
                    $" {updatedUser.Email} did not match stored password ",
                    OperationSuccessful = false,

                });
            }
            else
            {
                //if(changePassword != updatedUser.)
                var result = await _userManager.ChangePasswordAsync(updatedUser, changePassword.CurrentPassword, changePassword.NewPassword);
                if (result.Succeeded)
                {
                    return Ok(new OperationResponse
                    {
                        OperationMessage = $"The user {updatedUser.Email} has had their password " +
                        $"updated", 
                        OperationSuccessful = true });
                }
                else
                {
                    return BadRequest(new OperationResponse
                    {
                        OperationMessage = $"Something went wrong while trying to update the password " +
                        $"for the user: {updatedUser.Email}",
                        OperationSuccessful = false,

                    });
                }
            }
        }

        [HttpDelete("deleteSingleUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var deletedUser = await _userManager.FindByIdAsync(userId);
            if (deletedUser == null)
            {
                return NotFound(new OperationResponse
                { 
                    OperationMessage = $"User with Identiy Id: \"{userId}\" was not found",
                    OperationSuccessful = false 
                });
            }
            else
            {
                

                var result = await _userManager.DeleteAsync(deletedUser);
                if (result.Succeeded)
                {
                    await _datFitBase.SaveChangesAsync();
                    return Ok(new OperationResponse
                    {
                        OperationMessage = $"Something went wrong while trying to delete " +
                        $"the user: {deletedUser.Email}",
                        OperationSuccessful = true,
                        ReturnedObject = deletedUser
                    });
                }
                else
                {
                    return BadRequest( new OperationResponse
                    {
                        OperationMessage = $"Something went wrong while trying to delete " +
                        $"the user: {deletedUser.Email}",
                        OperationSuccessful = false
                    });
                }

            }
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterExpUser([FromForm] UserRegistrationDto userRegistration)
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
                user.ImageName = await SaveUserImage(userRegistration.UserPhoto);

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
                     React client since it was expecting Json to be returned*/

                    //return Ok($"{user.FirstName} {user.LastName} has been registered");
                    //String interpolation is similar-ish to Javascript              
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

        [NonAction]
        public async Task<string> SaveUserImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("mmddyyyy") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "FitAppImages", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create)) 
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

    }
}
