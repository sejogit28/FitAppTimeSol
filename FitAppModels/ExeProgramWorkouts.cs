using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels
{
    public class ExeProgramWorkouts
    {
        public int ExeProgramExeProgramId { get; set; }
        public ExeProgram ExeProgram { get; set; }

        public int ExeWorkoutExeWorkoutId { get; set; }
        public ExeWorkout ExeWorkout { get; set; }
    }
}
