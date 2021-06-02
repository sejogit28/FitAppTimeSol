using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class LibExe
    {
        [Key]
        public int LibExeId { get; set; }
        public string LibExeName { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }
    }
}
