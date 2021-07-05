using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.OrganizationViewModels
{
    public class AddProgramToOrganization
    {
        public string CoachId { get; set; }
        public int OrgId { get; set; }
        public int ProgramId { get; set; }
    }
}
