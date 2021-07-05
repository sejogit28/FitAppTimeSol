using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.OrganizationViewModels
{
    public class AddAthleteToOrganization
    {
        public string AthleteId { get; set; }
        public string CoachId { get; set; }
        public int OrganizationId { get; set; }

    }
}
