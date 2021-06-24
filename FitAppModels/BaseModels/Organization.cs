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
        public string OrganizationName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public IList<OrganizationFitAppUsers> OrganizationFitAppUsers { get; set; }
    }
}
