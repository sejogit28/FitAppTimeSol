using FitAppDataStoreEF;
using FitAppModels;
using FitAppModels.BaseModels;
using FitAppModels.ExeProgramViewModels;
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
    public class ExeProgramController : ControllerBase
    {
        private readonly FitAppDbContext _datFitBase;
        private readonly UserManager<FitAppUser> _userManager;
        

        public ExeProgramController(FitAppDbContext fitDB, UserManager<FitAppUser> userManager)
        {
            _datFitBase = fitDB;
            _userManager = userManager;
            
        }

        [HttpGet("exeprogramlist")]
        public async Task<IActionResult> GetExePrograms()
        {
            var exeProgramList = await _datFitBase.ExeProgram.ToListAsync();
            return Ok(exeProgramList);
        }

        [HttpGet("exeprogrambyuser/{fitAppUserId}")]
        public async Task<IActionResult> GetExeProgramsByUser(string fitAppUserId)
        {
            var exeProgramByUserList = await _datFitBase.ExeProgram.Where(t => t.FitAppUserId == fitAppUserId)
                .ToListAsync();
            return Ok(exeProgramByUserList);
        }

        [HttpGet("singleexeprogram/{singleExeProgramId:int}")]
        public async Task<IActionResult> GetSingleExeProgram(int singleExeProgramId)
        {
            var exeProgram = await _datFitBase.ExeProgram.FindAsync(singleExeProgramId);
            if (exeProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..couldn't find the requested program",
                });
            }
            return Ok(exeProgram);
        }

        [HttpPost("createexeprogram")]
        public async Task<IActionResult> createExeProgram([FromBody] ExeProgram newExeProgram)
        {
            //newExpense.MonthYear = newExpense.DateSpent.ToString("yyyy-MM");
            await _datFitBase.ExeProgram.AddAsync(newExeProgram);
            await _datFitBase.SaveChangesAsync();
            return Ok(new OperationResponse
            {
                OperationSuccessful = true,
                OperationMessage = $"Success!! {newExeProgram.ExeProgramTitle} has been created!",
                ReturnedObject = newExeProgram
            });
        }

        [HttpPut("updateexeprogram/{updatedExeProgramId:int}")]
        public async Task<IActionResult> updateExeProgram(int updatedExeProgramId, [FromBody] ExeProgram updatedExeProgram)
        {
            if (updatedExeProgramId != updatedExeProgram.ExeProgramId) return BadRequest(new OperationResponse
            {
                OperationSuccessful = false,
                OperationMessage = "Operation has been cancelled..something went wrong..."
            });
            _datFitBase.Entry(updatedExeProgram).State = EntityState.Modified;
            try
            {
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! {updatedExeProgram.ExeProgramTitle} has been updated!",
                    ReturnedObject = updatedExeProgram
                });
            }
            catch
            {
                if (await _datFitBase.ExeProgram.FindAsync(updatedExeProgramId) == null)
                {
                    return BadRequest(new OperationResponse
                    {
                        OperationSuccessful = false,
                        OperationMessage = "Operation has been cancelled..the program could not be found"
                    });
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("deleteexeprogram/{deletedExeProgramId:int}")]
        public async Task<IActionResult> deleteExeProgram(int deletedExeProgramId)
        {
            var deletedExeProgram = await _datFitBase.ExeProgram.FindAsync(deletedExeProgramId);
            if (deletedExeProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the program could not be found"
                });
            }

            _datFitBase.ExeProgram.Remove(deletedExeProgram);
            await _datFitBase.SaveChangesAsync();
            return Ok(new OperationResponse
            {
                OperationSuccessful = true,
                OperationMessage = "Success...Program deleted"
            });

        }

        [HttpPost("addworkouttoprogram/{coachId}/{programId:int}/{workoutId:int}")]
        public async Task<IActionResult> addWorkoutToProgram([FromBody] AddWorkoutToProgram addWorkoutToProgram, string coachId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(addWorkoutToProgram.ExeProgramId);
            var currentWorkout = await _datFitBase.ExeWorkout.FindAsync(addWorkoutToProgram.ExeWorkoutId);
            var currentCoach = await _userManager.FindByIdAsync(addWorkoutToProgram.CoachId);
            var currentOrg = await _datFitBase.Organizations.FindAsync(addWorkoutToProgram.OrgId);

            if(coachId != addWorkoutToProgram.CoachId) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..something went wrong"
                });
            }
            //May or not be a reason to repeat what you did directly above this comment for the other model values...

            if (currentProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the program could not be found"
                });
            }

            if (currentWorkout == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the workout could not be found"
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
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " add this workout to this program"
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
                    " this workout to this program."
                });
            }

            var orgProgramCheck = await _datFitBase.OrganizationExePrograms
                .FindAsync(currentOrg.OrganizationId, currentProgram.ExeProgramId);

            if(orgProgramCheck == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The program is not apart of this organization and cannot have" +
                    " a workout added to it from here."
                });
            }
            var programCheck = await _datFitBase.ExeProgramWorkouts
                .FindAsync(currentProgram.ExeProgramId, currentWorkout.ExeWorkoutId);
            if (programCheck == null)
            {
                var newExeProgramWorkout = new ExeProgramWorkouts
                {
                    ExeProgramExeProgramId = currentProgram.ExeProgramId,
                    ExeWorkoutExeWorkoutId = currentWorkout.ExeWorkoutId
                };
                await _datFitBase.ExeProgramWorkouts.AddAsync(newExeProgramWorkout);
                await _datFitBase.SaveChangesAsync();

                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! {currentWorkout.ExeWorkoutTitle} has been saved" +
                    $" to {currentProgram.ExeProgramTitle}"
                });
            }

            else
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation cancelled...this workout is already in this program"
                });

            }
        }

        [HttpDelete("deleteworkoutfromprogram/{coachId}/{orgId:int}/{programId:int}/{workoutId:int}")]
        public async Task<IActionResult> deleteWorkoutFromProgram(int programId, int workoutId, string coachId, int orgId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentWorkout = await _datFitBase.ExeWorkout.FindAsync(workoutId);
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

            if (currentWorkout == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the workout could not be found"
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
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " add this workout to this program"
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
                    " this workout to this program."
                });
            }

            var orgProgramCheck = await _datFitBase.OrganizationExePrograms
                .FindAsync(currentOrg.OrganizationId, currentProgram.ExeProgramId);

            if (orgProgramCheck == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The program is not apart of this organization and cannot have" +
                    " a workout added to it from here."
                });
            }

            var currentExeProgramWorkout = await _datFitBase.ExeProgramWorkouts
                .FindAsync(currentProgram.ExeProgramId, currentWorkout.ExeWorkoutId);
            if (currentExeProgramWorkout == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The requested workout you tried to remove from the requested " +
                    "program is not currently in that program"
                });
            }
            else
            {
                _datFitBase.ExeProgramWorkouts.Remove(currentExeProgramWorkout);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = "Workout removed successfully"
                });
            }

        }

        [HttpPost("addathletetoprogram/{programId:int}/{coachId}")]
        //If an athlete is added to a program it allows them to see the programs workouts,
        //    if a coach is with a program it's cause they wrote it(assign athlete to calendar...)
        public async Task<IActionResult> addUserToProgram([FromBody] AddAthleteToProgram addAthleteToProgram)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(addAthleteToProgram.ExeProgramId);
            var currentCoach = await _userManager.FindByIdAsync(addAthleteToProgram.CoachId);
            var currentAthlete = await _userManager.FindByIdAsync(addAthleteToProgram.AthleteId);
            if (currentProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the program could not be found"
                });
            }

            if (currentAthlete == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the athlete could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the coach could not be found"
                });
            }

            var athleteCheck = await _userManager.IsInRoleAsync(currentAthlete, "Athlete");
            if(athleteCheck == false) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the user you attempted to add to the " +
                    "program is a coach. Coaches can't be added to programs"
                });
            }

            var programCheck = await _datFitBase.FitAppUserExePrograms
                .FindAsync(currentProgram.ExeProgramId, currentAthlete.Id);
            if (programCheck == null)
            {
                var newExeProgramUser = new FitAppUserExePrograms
                {
                    FitAppUserId = currentAthlete.Id,
                    ExeProgramExeProgramId = currentProgram.ExeProgramId
                };

                await _datFitBase.AddAsync(newExeProgramUser);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = $"Success!! The athlete {currentAthlete.FirstName} has been added to " +
                    $"{currentProgram.ExeProgramTitle}!"
                });
            }
            else
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is already apart of this program..."
                });
            }
        }

        [HttpDelete("removeathletefromprogram/{programId:int}/{orgId:int}/{coachId}/{athleteId}")]
        public async Task<IActionResult> removeAthleteFromProgram(int programId,int orgId, string athleteId, string coachId)
        {
            //Coach is doing this...
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentOrg = await _datFitBase.Organizations.FindAsync(orgId);
            var currentAthlete = await _userManager.FindByIdAsync(athleteId);
            var currentCoach = await _userManager.FindByIdAsync(coachId);
            if (currentProgram == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...the program could not be found"
                });
            }

            if (currentAthlete == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the athlete could not be found"
                });
            }

            if (currentCoach == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled..the coach could not be found"
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

            if (await _userManager.IsInRoleAsync(currentCoach, "Athlete") == true )
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation has been cancelled...this user is not a coach and can not" +
                    " remove this athlete from this program"
                });
            }

            if (await _userManager.IsInRoleAsync(currentAthlete, "Athlete") != true)
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
            if(athleteOrgCheck == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "Operation cancelled...this athlete is not in this organization"
                });
            }

            var currentExeProgramUser = await _datFitBase.FitAppUserExePrograms
                .FindAsync(currentProgram.ExeProgramId, currentAthlete.Id);
            if (currentExeProgramUser == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The requested athlete you tried to remove is not currently assigned" +
                    " to this program"
                });
            }
            else
            {
                _datFitBase.FitAppUserExePrograms.Remove(currentExeProgramUser);
                await _datFitBase.SaveChangesAsync();
                return Ok(new OperationResponse
                {
                    OperationSuccessful = true,
                    OperationMessage = "Athlete removed from program successfully"
                });
            }

        }
    }
}
