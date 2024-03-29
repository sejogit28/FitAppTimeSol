﻿using FitAppModels.MTMModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class ExeWorkout
    {
        [Key]
        public int ExeWorkoutId { get; set; }

        [MaxLength(400)]
        public string GoalNotes { get; set; }

        [Required]
        [MaxLength(250)]
        public string ExeWorkoutTitle { get; set; }

        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }

        public IList<Exe> Exe { get; set; }

        public IList<ExeProgramWorkouts> ExeProgramWorkouts { get; set; }

        public IList<OrganizationExeWorkouts> OrganizationExeWorkouts { get; set; }


    }
}
