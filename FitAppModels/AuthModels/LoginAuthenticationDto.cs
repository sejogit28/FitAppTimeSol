using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class LoginAuthenticationDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public bool IsLoginSuccessful { get; set; }

        public string Id { get; set; }

        public string FirstName { get;set; }

        public string LastName { get; set; }

        public IList<string> Roles { get; set; }

        public string Email { get; set; }

        public string ResponseMessage { get; set; }
        public string Token { get; set; }
    }
}
