using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.OrganizationViewModels
{
    public class AddLooseWorkoutToOrganization
    {
        public string CoachId { get; set; }
        public int OrgId { get; set; }
        public int WorkoutId { get; set; }
    }
}
