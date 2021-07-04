using FitAppDataStoreEF;
using FitAppModels;
using FitAppModels.BaseModels;
using FitAppModels.MTMModels;
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

        public OrganizationsController(FitAppDbContext fitDB, UserManager<FitAppUser> userManager)
        {
            _datFitBase = fitDB;
            _userManager = userManager;

        }

        [HttpGet("organizationlist")]
        public async Task<IActionResult> GetOrganizations()
        {
            var orgList = await _datFitBase.Organizations.ToListAsync();
            return Ok(orgList);
        }

        [HttpGet("organizationsbyuser/{fitAppUserId}")]
        public async Task<IActionResult> GetOrganizationsByUser(string fitAppUserId) 
        {
            var orgsByUser = await _datFitBase.Organizations.Where(t => t.FitAppUserId == fitAppUserId)
                .ToListAsync();
            if (orgsByUser == null || orgsByUser.Count == 0)
            {
                orgsByUser = new List<Organizations>();
                return Ok(orgsByUser);
            }
            return Ok(orgsByUser);
        }

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

        [HttpPut("updateorganization/{updatedOrganizationId:int}")]
        public async Task<IActionResult> updateOrganization(int updatedOrganizationId, [FromBody] Organizations updatedOrganization)
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

        [HttpPost("addusertorganization/{orgId:int}/{userId}")]
        public async Task<IActionResult> addUserToOrganization(int orgId, string userId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);
            var currentUser = await _userManager.FindByIdAsync(userId);

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentUser == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user could not be found"
                });
            }

            var orgCheck = await _datFitBase.OrganizationFitAppUsers.FindAsync(currentOrg.OrganizationId, currentUser.Id);
            if (orgCheck == null)
            {
                var newOrganizationUser = new OrganizationFitAppUsers
                {
                    OrganizationsOrganizationId = currentOrg.OrganizationId,
                    FitAppUserId = currentUser.Id
                };
                await _datFitBase.OrganizationFitAppUsers.AddAsync(newOrganizationUser);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! The user {currentUser.FirstName} has been saved to the organization: {currentOrg.OrganizationName}"
                });
            }

            else
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation cancelled...this user is already in this organization"
                });

            }

        }

        [HttpDelete("deleteuserfromorganization/{orgId:int}/{userId}")]
        public async Task<IActionResult> deleteUserFromOrganization(int orgId, string userId)
        {
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);
            var currentUser = await _userManager.FindByIdAsync(userId);

            if (currentOrg == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the organization could not be found"
                });
            }

            if (currentUser == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user could not be found"
                });
            }

            var currentOrgUser = await _datFitBase.OrganizationFitAppUsers.FindAsync(currentOrg.OrganizationId, currentUser.Id);
            if (currentOrgUser == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The requested user you tried to remove from the requested organization is not currently in that organization"
                });
            }
            else
            {
                _datFitBase.OrganizationFitAppUsers.Remove(currentOrgUser);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success...the user {currentUser.FirstName} has been successfully removed from {currentOrg.OrganizationName}"
                });
            }

        }


    }
}
