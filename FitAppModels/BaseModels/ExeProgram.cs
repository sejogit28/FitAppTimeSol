using FitAppModels.MTMModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class ExeProgram
    {
        [Key]
        public int ExeProgramId { get; set; }
        [MaxLength(75)]
        public string ExeProgramTitle { get; set; }

        [Required]
        [MaxLength(150)]
        public string Goal { get; set; }
        [MaxLength(300)]
        public string GoalNotes { get; set; }

        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }

        //public IList<FitAppUserExePrograms> FitAppUserExePrograms { get; set; }

        public IList<ExeProgramWorkouts> ExeProgramWorkouts { get; set;}
        public IList<OrganizationExePrograms> OrganizationExePrograms { get; set; }
    }


}
