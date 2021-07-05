using FitAppDataStoreEF;
using FitAppModels;
using FitAppModels.BaseModels;
using FitAppModels.MTMModels;
using FitAppModels.OrganizationViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAppTimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly FitAppDbContext _datFitBase;
        private readonly UserManager<FitAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public OrganizationsController(FitAppDbContext fitDB, UserManager<FitAppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _datFitBase = fitDB;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("organizationlist")]
        public async Task<IActionResult> GetOrganizations()
        {
            var orgList = await _datFitBase.Organizations.ToListAsync();
            return Ok(orgList);
        }

        //[HttpGet("organizationsbyuser/{fitAppUserId}")]
        //public async Task<IActionResult> GetOrganizationsByUser(string fitAppUserId) 
        //{
        //    var orgsByUser = await _datFitBase.Organizations.Where(t => t.FitAppUserId == fitAppUserId)
        //        .ToListAsync();
        //    if (orgsByUser == null || orgsByUser.Count == 0)
        //    {
        //        orgsByUser = new List<Organizations>();
        //        return Ok(orgsByUser);
        //    }
        //    return Ok(orgsByUser);
        //}

        [HttpGet("singleorganization/{singleOrganizationId:int}")]
        public async Task<IActionResult> GetSingleOrganization(int singleOrganizationId)
        {
            var singleOrg = await _datFitBase.Organizations.FindAsync(singleOrganizationId);
            if (singleOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...couldn't find the requested organization",
                });
            }
            return Ok(singleOrg);
        }

        [HttpPost("createorganization")]
        public async Task<IActionResult> createOrganization([FromBody] Organizations newOrganization)
        {
            await _datFitBase.Organizations.AddAsync(newOrganization);

            await _datFitBase.SaveChangesAsync();
            return Ok(new OperationResponse
            {
                OperationSuccessful = true,
                OperationMessage = $"Success!! The organization: {newOrganization.OrganizationName} has been created!",
                ReturnedObject = newOrganization
            });
        }

        [HttpPost("addfirstcoachtoneworganization/{userId}")]
        public async Task<IActionResult> AddFirstCoachToNewOrganization([FromBody] AddFirstCoachToNewOrganization addFirstCoachToNewOrganization, string userId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(addFirstCoachToNewOrganization.CurrentOrgId);
            var firstCoach = await _userManager.FindByIdAsync(addFirstCoachToNewOrganization.FirstCoachId);

            if (addFirstCoachToNewOrganization.FirstCoachId != userId)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, something went wrong..."
                });
            }

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (firstCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach could not be found"
                });
            }

            var currentCoachRoles = await _userManager.GetRolesAsync(firstCoach);

            if (!currentCoachRoles.Intersect(GetListofCoachRoles()).Any())
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " be the first added to this organization"
                });
            }
            if(currentOrg.FitAppUserId != addFirstCoachToNewOrganization.FirstCoachId) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Something went wrong....."
                });
            }
            var possibleCoachOrgCheck = await _datFitBase.OrganizationFitAppUsers
               .FindAsync(currentOrg.OrganizationId, firstCoach.Id);

            if (possibleCoachOrgCheck != null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, the coach you are trying to add is already " +
                    "a member of your organization"
                });
            }
            else
            {

                var newOrganizationCoach = new OrganizationFitAppUsers
                {
                    OrganizationsOrganizationId = currentOrg.OrganizationId,
                    FitAppUserId = addFirstCoachToNewOrganization.FirstCoachId
                };
                await _datFitBase.OrganizationFitAppUsers.AddAsync(newOrganizationCoach);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! The coach {firstCoach.FirstName} has started and been added to" +
                    $" their organization: {currentOrg.OrganizationName}!!"
                });
            }


        }

        [HttpPut("updateorganization/{updatedOrganizationId:int}/{updatingCoachId}")]
        public async Task<IActionResult> updateOrganization(int updatedOrganizationId, string updatingCoachId, [FromBody] Organizations updatedOrganization)
        {
            if (updatedOrganizationId != updatedOrganization.OrganizationId) return BadRequest(new OperationResponse
            {
                OperationSuccessful = false,
                OperationMessage = "Operation has been cancelled...something went wrong..."
            });
            _datFitBase.Entry(updatedOrganization).State = EntityState.Modified;
            try
            {
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! {updatedOrganization.OrganizationName} has been updated!",
                    ReturnedObject = updatedOrganization
                });
            }
            catch
            {
                if (await _datFitBase.Organizations.FindAsync(updatedOrganizationId) == null)
                {
                    return BadRequest(new OperationResponse
                    {
                        OperationSuccessful = false,
                        OperationMessage = "Operation has been cancelled...the organization could not be found"
                    });
                    throw;
                }
            }
            return NoContent();

        }

        [HttpDelete("deleteorganization/{deletedOrganizationId:int}")]
        public async Task<IActionResult> deleteExeProgram(int deletedOrganizationId)
        {
            var deletedOrganization = await _datFitBase.Organizations.FindAsync(deletedOrganizationId);
            if (deletedOrganization == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            _datFitBase.Organizations.Remove(deletedOrganization);
            await _datFitBase.SaveChangesAsync();
            return Ok(new OperationResponse
            {
                OperationSuccessful = true,
                OperationMessage = "Success...Organization deleted"
            });

        }

        [HttpPost("addcoachtoorganization/{orgId:int}/{currentOrgCoachId}")]
        public async Task<IActionResult> addCoachToOrganization([FromBody] AddCoachToOrganization addCoachToOrganization, string currentOrgCoachId, int orgId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(addCoachToOrganization.CurrentOrgId);
            var possibleCoach = await _userManager.FindByEmailAsync(addCoachToOrganization.PossibleCoachEmail);
            var currentCoach = await _userManager.FindByIdAsync(addCoachToOrganization.CurrentCoachId);
            

            if (addCoachToOrganization.CurrentCoachId != currentOrgCoachId)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, something went wrong..."
                });
            }

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach could not be found"
                });
            }

            var currentCoachRoles = await _userManager.GetRolesAsync(currentCoach);

            if (possibleCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach could not be found. Make sure" +
                    " they have signed up before trying to add them to your org"
                });
            }

            var possibleCoachRoles = await _userManager.GetRolesAsync(possibleCoach);

            if (!currentCoachRoles.Intersect(GetListofCoachRoles()).Any())
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " add another coach to an organization"
                });
            }

            if (!possibleCoachRoles.Intersect(GetListofCoachRoles()).Any())
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user you attempted to add as a coach " +
                    "is not a coach"
                });
            }

            var currentCoachOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);

            if(currentCoachOrgCheck == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, the coach trying to add a new coach isn't" +
                    " a member of this organization"
                });
            }

            var possibleCoachOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, possibleCoach.Id);

            if (possibleCoachOrgCheck != null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, the coach you are trying to add is already " +
                    "a member of your organization"
                });
            }
            else 
            {
                //Need to add in check to see level of organization in order to maintain correct coach limits
                var newOrganizationCoach = new  OrganizationFitAppUsers
                {
                    OrganizationsOrganizationId = currentOrg.OrganizationId,
                    FitAppUserId = possibleCoach.Id
                };
                await _datFitBase.OrganizationFitAppUsers.AddAsync(newOrganizationCoach);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! The coach {possibleCoach.FirstName} has been added to" +
                    $" the organization: {currentOrg.OrganizationName}"
                });
            }

            
        }

        [HttpDelete("deletecoachfromorganization/{orgId:int}/{currentOrgCoachId}/{deletedCoachId}")]
        public async Task<IActionResult> deleteCoachFromOrganization(string deletedCoachId, string currentOrgCoachId, int orgId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);
            var leavingCoach = await _userManager.FindByIdAsync(deletedCoachId);
            var currentCoach = await _userManager.FindByIdAsync(currentOrgCoachId);
            var currentCoachRoles = await _userManager.GetRolesAsync(currentCoach);

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach could not be found"
                });
            }

            if (leavingCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the coach you are trying to remove from " +
                    "your org could not be found."
                });
            }

            if (!currentCoachRoles.Intersect(GetListofCoachRoles()).Any())
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " remove a coach from the organization"
                });
            }

            var currentCoachOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);

            if (currentCoachOrgCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, the coach trying to remove a the coach isn't" +
                    " a member of this organization"
                });
            }

            var leavingCoachOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, leavingCoach.Id);

            if (leavingCoachOrgCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, the coach you are trying to remove is not " +
                    "a member of your organization"
                });
            }
            else
            {
                _datFitBase.OrganizationFitAppUsers.Remove(leavingCoachOrgCheck);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success, The coach {leavingCoach.FirstName} has been removed from the" +
                    $" the organization: {currentOrg.OrganizationName}"
                });
            }


        }

        [HttpPost("addathletetoorganization/{orgId:int}/{athleteId}")]
        public async Task<IActionResult> addUserToOrganization([FromBody] AddAthleteToOrganization addAthleteToOrganization, string athleteId, int orgId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(addAthleteToOrganization.OrganizationId);
            var currentAthlete = await _userManager.FindByIdAsync(addAthleteToOrganization.AthleteId);
            var currentCoach = await _userManager.FindByIdAsync(addAthleteToOrganization.CoachId);
           
            
            if(addAthleteToOrganization.AthleteId != athleteId) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled, something went wrong..."
                });
            }

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach could not be found"
                });
            }

            //var listOfRolesAsStrings = _roleManager.Roles.Select(x => x.Name).ToList();
            //var athleteIndex = listOfRolesAsStrings.IndexOf("Athlete");
            //listOfRolesAsStrings.RemoveAt(athleteIndex);
            var currentCoachRoles = await _userManager.GetRolesAsync(currentCoach);

            if (! currentCoachRoles.Intersect(GetListofCoachRoles()).Any())
            //Could also do _userManager.IsInRole(currentCoach ,"Athlete"
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " add an athlete to an organization"
                });
            }

            if (currentAthlete == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this athlete could not be found"
                });
            }
            
            if(await _userManager.IsInRoleAsync(currentAthlete, "Athlete") == false) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not an athlete"
                });
            }

            var coachOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);

            if (coachOrgCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this coach is not a part of this " +
                    "organization"
                });
            }

            var athleteOrgCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentAthlete.Id);
            if (athleteOrgCheck == null)
            {
                var newOrganizationAthlete = new OrganizationFitAppUsers
                {
                    OrganizationsOrganizationId = currentOrg.OrganizationId,
                    FitAppUserId = currentAthlete.Id
                };
                await _datFitBase.OrganizationFitAppUsers.AddAsync(newOrganizationAthlete);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! The athlete {currentAthlete.FirstName} has been added to" +
                    $" the organization: {currentOrg.OrganizationName}"
                });
            }

            else
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation cancelled...this athlete is already in this organization"
                });

            }

        }

        [HttpDelete("deleteathletefromorganization/{orgId:int}/{coachId}/{athleteId}")]
        public async Task<IActionResult> deleteUserFromOrganization(int orgId, string coachId, string athleteId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);
            var currentAthlete = await _userManager.FindByIdAsync(athleteId);
            var currentCoach = await _userManager.FindByIdAsync(coachId);

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the coach could not be found"
                });
            }

            var currentCoachRoles = await _userManager.GetRolesAsync(currentCoach);
            if (!currentCoachRoles.Intersect(GetListofCoachRoles()).Any())
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " add an athlete to an organization"
                });
            }

            if (currentAthlete == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user could not be found"
                });
            }

            if ( await _userManager.IsInRoleAsync(currentAthlete, "Athlete") == false)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the user you are trying to remove is not" +
                    " an athlete"
                });
            }
            var currentOrgCoachCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);
            if (currentOrgCoachCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The specified coach is not apart of this organization and cannot remove" +
                    " an athlete from it"
                });
            }

            var currentOrgAthleteCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentAthlete.Id);
            if (currentOrgAthleteCheck == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The athlete you tried to remove is not currently in this organization"
                });
            }
            else
            {
                _datFitBase.OrganizationFitAppUsers.Remove(currentOrgAthleteCheck);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success...the athlete {currentAthlete.FirstName} has been successfully " +
                    $"removed from {currentOrg.OrganizationName}"
                });
            }

        }

        [HttpPost("addprogramtoorganization/{coachId}/{orgId:int}/")]
        public async Task<IActionResult> addProgramToOrganization([FromBody] AddProgramToOrganization addProgramToOrganization, string coachId, int orgId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(addProgramToOrganization.ProgramId);
            var currentCoach = await _userManager.FindByIdAsync(addProgramToOrganization.CoachId);
            var currentOrg = await _datFitBase.Organizations.FindAsync(addProgramToOrganization.OrgId);

            if(orgId != addProgramToOrganization.OrgId) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...something went wrong"
                });
            }

            if (coachId != addProgramToOrganization.CoachId)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...something went wrong"
                });
            }
            if (currentProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the program could not be found"
                });
            }

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the coach could not be found"
                });
            }

            if (await _userManager.IsInRoleAsync(currentCoach, "Athlete") == true)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the user trying to add this " +
                    "program is not a coach"
                });
            }

            var currentOrgCoachCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);
            if (currentOrgCoachCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The specified coach is not apart of this organization and cannot add" +
                    " this program to it"
                });
            }

            var currentOrgProgramCheck = await _datFitBase.OrganizationExePrograms
                .FindAsync(currentOrg.OrganizationId, currentProgram.ExeProgramId);
            if(currentOrgProgramCheck != null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The program you tried to add is already in this organization"
                });
            }
            else 
            {
                var newOrgExeProgram = new OrganizationExePrograms
                {
                    OrganizationsOrganizationId = currentOrg.OrganizationId,
                    ExeProgramExeProgramId = currentProgram.ExeProgramId
                };

                await _datFitBase.OrganizationExePrograms.AddAsync(newOrgExeProgram);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! {currentProgram.ExeProgramTitle} has been saved" +
                    $" to {currentOrg.OrganizationName}"
                });
                
            }
            
        }

        [HttpDelete("removeprogramtoorganization/{coachId}/{orgId:int}/{programId:int}")]
        public async Task<IActionResult> removeProgramFoOrganization(string coachId, int orgId, int programId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentCoach = await _userManager.FindByIdAsync(coachId);
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);

            if (currentProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the program could not be found"
                });
            }

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the coach could not be found"
                });
            }

            var currentOrgCoachCheck = await _datFitBase.OrganizationFitAppUsers
                .FindAsync(currentOrg.OrganizationId, currentCoach.Id);
            if (currentOrgCoachCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The specified coach is not apart of this organization and cannot add" +
                    " this program to it"
                });
            }

            if (await _userManager.IsInRoleAsync(currentCoach, "Athlete") == true)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the user trying to add this " +
                    "program is not a coach"
                });
            }

            var currentOrgProgramCheck = await _datFitBase.OrganizationExePrograms
                .FindAsync(currentOrg.OrganizationId, currentProgram.ExeProgramId);

            if (currentOrgProgramCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The program you tried to remove isn't in this organization"
                });
            }
            else
            {


                _datFitBase.OrganizationExePrograms.Remove(currentOrgProgramCheck);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! {currentProgram.ExeProgramTitle} has been removed" +
                    $" from {currentOrg.OrganizationName}"
                });

            }

        }

        private IList<string> GetListofCoachRoles() 
        {

            //IList<string> listOfCoachingRoles = new List<string>(
            //    new string[] { "Coach", "Level 1 Organization", "Level 2 Organization",
            //    "Level 3 Organization", "Level 4 Organization", "Level 5 Organization", "Admin"});

            var listOfRolesAsStrings = _roleManager.Roles.Select(x => x.Name).ToList();
            var athleteIndex = listOfRolesAsStrings.IndexOf("Athlete");
            listOfRolesAsStrings.RemoveAt(athleteIndex);
            return listOfRolesAsStrings;
        }


    }
}
