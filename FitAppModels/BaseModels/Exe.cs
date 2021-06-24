using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class Exe
    {
        [Key]
        public int ExeId { get; set; }
        public string ExeName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Time { get; set; }
        public bool EachSide { get; set; }
        public string WorkoutGroup { get; set; }
        public int WorkoutGroupOrder { get; set; }
        public string Tempo { get; set; }
        public int Rest { get; set; }
        public string ExeNotes { get; set;}

        //ExeType == List that wil be made in the front end
        public string ExeType { get; set; }


        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }
        [Required]
        public int ExeWorkoutExeWorkoutId { get; set; }
        public ExeWorkout ExeWorkout { get; set; }
    }
}
