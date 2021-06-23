using FitAppDataStoreEF;
using FitAppModels;
using Microsoft.AspNetCore.Http;
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

        public ExeProgramController(FitAppDbContext fitDB)
        {
            _datFitBase = fitDB;
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
                OperationMessage = $"Success!! {newExeProgram.Title} has been created!",
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
                        OperationMessage = $"Success!! {updatedExeProgram.Title} has been updated!",
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
        public async Task<IActionResult> addWorkoutToProgram(int programId, int workoutId) 
        {
            var currentProgram = await _datFitBase.ExeProgram.FindAsync(programId);
            var currentWorkout = await _datFitBase.ExeWorkout.FindAsync(workoutId);

            if(currentProgram == null) 
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

            var programCheck = await _datFitBase.ExeProgramWorkouts.FindAsync(currentProgram.ExeProgramId, currentWorkout.ExeWorkoutId);
            if(programCheck == null) 
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
                    OperationMessage = $"Success!! {currentWorkout.Title} has been saved to {currentProgram.Title}"
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
                return BadRequest (new OperationResponse 
                {
                    OperationSuccessful= false,
                    OperationMessage = "Operation has been cancelled..the workout could not be found"
                });
            }

            var currentExeProgramWorkout = await _datFitBase.ExeProgramWorkouts.FindAsync(currentProgram.ExeProgramId, currentWorkout.ExeWorkoutId);
            if (currentExeProgramWorkout == null) 
            {
                return BadRequest(new OperationResponse
                {
                    OperationSuccessful = false,
                    OperationMessage = "The requested workout you tried to remove from the requested program is not currently in that program"
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

    }
}
