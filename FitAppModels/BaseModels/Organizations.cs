using FitAppModels.MTMModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class Organizations
    {
        [Key]
        public int OrganizationId { get; set; }
        [Required]
        [MaxLength(100)]
        public string OrganizationName { get; set; }

        //Consult role configuration file to understand relevance
        [Required]
        public int OrganizationLevel { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public string FitAppUserId { get; set; }
        public string FitAppUserFirstName { get; set; }
        public FitAppUser FitAppUser { get; set; }
        public IList<OrganizationFitAppUsers> OrganizationFitAppUsers { get; set; }
        public IList<OrganizationExeWorkouts> OrganizationExeWorkouts { get; set; }
        public IList<OrganizationExePrograms> OrganizationExePrograms { get; set; }


    }
}
