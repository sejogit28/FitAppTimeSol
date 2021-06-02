using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.AuthModels
{
    public class ChangePassword
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        [MaxLength(50)]
        public string ConfirmNewPassword { get; set; }
    }
}
