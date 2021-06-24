using FitAppModels.MTMModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAppModels.BaseModels
{
    public class FitAppUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(140)]
        public string LastName { get; set; }
        public DateTime DateAdded { get; set; }

        public IList<FitAppUserExePrograms> FitAppUserExePrograms  { get;set;}

        public IList<OrganizationFitAppUsers> OrganizationFitAppUsers { get; set; }

    }



}
