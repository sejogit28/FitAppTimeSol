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

        [HttpPost("addworkouttoprogram/{programId:int}/{workoutId:int}")]
        public async Task<IActionResult> addWorkoutToProgram([FromBody] AddWorkoutToProgram addWorkoutToProgram)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(addWorkoutToProgram.ExeProgramId);
            var currentWorkout = await _datFitBase.ExeWorkout.FindAsync(addWorkoutToProgram.ExeWorkoutId);

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

        [HttpDelete("deleteworkoutfromprogram/{programId:int}/{workoutId:int}")]
        public async Task<IActionResult> deleteWorkoutFromProgram(int programId, int workoutId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentWorkout = await _datFitBase.ExeWorkout.FindAsync(workoutId);

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

        [HttpPost("addathletetoprogram/{programId:int}/{userId}")]
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

        [HttpDelete("removeuserfromprogram/{programId:int}/{userId}")]
        public async Task<IActionResult> removeUserFromProgram(int programId, string userId)
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentAthlete = await _userManager.FindByIdAsync(userId);
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
                    OperationMessage = "Operation has been cancelled..the user could not be found"
                });
            }

            var currentExeProgramUser = await _datFitBase.FitAppUserExePrograms
                .FindAsync(currentProgram.ExeProgramId, currentAthlete.Id);
            if (currentExeProgramUser == null)
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The requested user you tried to remove from the requested program " +
                    "is not currently in that program"
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
