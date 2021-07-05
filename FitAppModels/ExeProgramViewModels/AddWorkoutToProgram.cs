using FitAppModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.ExeProgramViewModels
{
    public class AddWorkoutToProgram
    {
        public int ExeWorkoutId { get; set; }
        public int ExeProgramId { get; set; }
        public string CoachId { get; set; }
        public int OrgId { get; set; }
    }
}
