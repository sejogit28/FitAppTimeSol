using FitAppModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.MTMModels
{
    public class OrganizationExePrograms
    {
        public int OrganizationsOrganizationId { get; set; }
        public Organizations Organizations { get; set; }

        public int ExeProgramExeProgramId { get; set; }
        public ExeProgram ExeProgram { get; set; }
    }
}
