using FitAppModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.MTMModels
{
    public class OrganizationFitAppUsers
    {
        public int OrganizationsOrganizationId { get; set; }
        public Organizations Organizations { get; set; }

        public string FitAppUserId { get; set; }
        public FitAppUser FitAppUser { get; set; }
    }
}
