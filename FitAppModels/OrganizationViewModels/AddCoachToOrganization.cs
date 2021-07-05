using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.OrganizationViewModels
{
    public class AddCoachToOrganization
    {
        public string CurrentCoachId { get; set; }
        public string PossibleCoachEmail { get; set; }
        public int CurrentOrgId { get; set; }
    }
}
