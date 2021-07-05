using FitAppModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.MTMModels
{
    public class OrganizationExeWorkouts
    {
        //Allows coaches to move their workouts from org to org
        public int OrganizationsOrganizationId { get; set; }
        public Organizations Organizations { get; set; }

        public int ExeWorkoutExeWorkoutId { get; set; }
        public ExeWorkout ExeWorkout { get; set; }
    }
}
