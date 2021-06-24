using FitAppModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.MTMModels
{
    public class FitAppUserExePrograms
    {
        public string FitAppUserId { get; set; }
        public FitAppUser FitAppUser { get; set; }
        public int ExeProgramExeProgramId { get; set; }
        public ExeProgram ExeProgram { get; set; }
    }
}
