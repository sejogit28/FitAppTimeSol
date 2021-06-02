using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class Workout
    {
        [Key]
        public string WorkoutId { get; set; }
        public string GoalNotes { get; set; }


        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }

        public IList<ExeProgramWorkouts> ExeProgramWorkouts { get; set; }

    }
}
