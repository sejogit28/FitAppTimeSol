using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [MaxLength(75)]
        public string Email { get; set; }

        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        [MaxLength(75)]
        public string ConfirmEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [MaxLength(50)]
        public string ConfirmPassword { get; set; }

        public bool IsCoach { get; set; }
        public bool IsAthlete { get; set; }

        public string ImageName { get; set; }
        public IFormFile UserPhoto { get; set; }
    }
}
