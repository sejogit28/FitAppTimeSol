using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class ExeWorkout
    {
        [Key]
        public int ExeWorkoutId { get; set; }

        [MaxLength(400)]
        public string GoalNotes { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }

        //public IList<ExeProgramWorkouts> ExeProgramWorkouts { get; set; }

    }
}
