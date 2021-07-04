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
        [MaxLength(150)]
        public string ExeName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Time { get; set; }
        public bool EachSide { get; set; }
        [Required]
        [MaxLength(5)]
        public string WorkoutGroup { get; set; }
        [Required]
        public int WorkoutGroupOrder { get; set; }
        [MaxLength(25)]
        public string Tempo { get; set; }
        public int Rest { get; set; }
        [MaxLength(200)]
        public string ExeNotes { get; set;}

        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }
        [Required]
        public int ExeWorkoutExeWorkoutId { get; set; }
        public ExeWorkout ExeWorkout { get; set; }
    }
}
