using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class LibExe
    {
        [Key]
        public int LibExeId { get; set; }
        [Required]
        [MaxLength(75)]
        public string LibExeName { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public bool EachSide { get; set; }
        [MaxLength(75)]
        public string VideoUrl { get; set; }
        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }
    }
}
