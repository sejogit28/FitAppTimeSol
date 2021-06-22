using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class UserExeValues
    {
        public string FitAppUserId { get; set; }
        public FitAppUser FitAppUser { get; set; }
        public int ExeExeId { get; set; }
        public Exe Exe { get; set; }

        public DateTime EnteredValuesDate { get; set; }
        [MaxLength(50)]
        public string Set1Values { get; set; }
        [MaxLength(50)]
        public string Set2Values { get; set; }
        [MaxLength(50)]
        public string Set3Values { get; set; }
        [MaxLength(50)]
        public string Set4Values { get; set; }
        [MaxLength(50)]
        public string Set5Values { get; set; }
        [MaxLength(50)]
        public string Set6Values { get; set; }
        [MaxLength(50)]
        public string Set7Values { get; set; }
        [MaxLength(50)]
        public string Set8Values { get; set; }
        [MaxLength(50)]
        public string Set9Values { get; set; }
        [MaxLength(50)]
        public string Set10Values { get; set; }
    }
}
