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
    public class ExeWorkoutController : ControllerBase
    {
        private readonly FitAppDbContext _datFitBase;

        public ExeWorkoutController(FitAppDbContext fitDB)
        {
            _datFitBase = fitDB;
        }

        [HttpGet("exeworkoutlist")]
        public async Task<IActionResult> GetExeWokouts()
        {
            var exeWorkoutList = await _datFitBase.ExeWorkout.ToListAsync();
            return Ok(exeWorkoutList);
        }

        [HttpGet("exeworkoutsbyuser/{fitAppUserId}")]
        public async Task<IActionResult> GetExeWorkoutsByUser(string fitAppUserId)
        {

            var exeWorkoutsByUser = await _datFitBase.ExeWorkout.Where(t => t.FitAppUserId == fitAppUserId).ToListAsync();
            //var expensesByMonthList = await _datExpBase.Expenses.Where(t => t.MonthYear == targetMonth).ToListAsync();
            if (exeWorkoutsByUser == null || exeWorkoutsByUser.Count == 0)
            {
                exeWorkoutsByUser = new List<ExeWorkout>();
                return Ok(exeWorkoutsByUser);
            }
            return Ok(exeWorkoutsByUser);
        }

        [HttpGet("singleexeworkout/{singleExeWorkoutId:int}")]
        public async Task<IActionResult> GetExeWokout(int singleExeWorkoutId)
        {
            var exeWorkout = await _datFitBase.ExeWorkout.FindAsync(singleExeWorkoutId);
            if (exeWorkout == null)
            {
                return NotFound();
            }
            return Ok(exeWorkout);
        }

        [HttpPost("createexeworkout")]
        public async Task<IActionResult> createExeWokout([FromBody] ExeWorkout newExeWorkout)
        {
            await _datFitBase.ExeWorkout.AddAsync(newExeWorkout);
            await _datFitBase.SaveChangesAsync();
            return Ok(newExeWorkout);
        }

        [HttpPut("updateexeworkout/{updatedExeWorkoutId:int}")]
        public async Task<IActionResult> updateExeWorkout(int updatedExeWorkoutId, [FromBody] ExeWorkout updatedExeWorkout)
        {
            if (updatedExeWorkoutId != updatedExeWorkout.ExeWorkoutId) return BadRequest();
            _datFitBase.Entry(updatedExeWorkout).State = EntityState.Modified;
            try
            {
                await _datFitBase.SaveChangesAsync();
                return Ok(updatedExeWorkout);
            }
            catch
            {
                if (await _datFitBase.ExeWorkout.FindAsync(updatedExeWorkoutId) == null)
                {
                    return NotFound();
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("deleteeexeworkout/{deletedExeWorkoutId:int}")]
        public async Task<IActionResult> deleteExeWorkout(int deletedExeWorkoutId)
        {
            var deletedExeWorkout = await _datFitBase.ExeWorkout.FindAsync(deletedExeWorkoutId);
            if (deletedExeWorkout == null)
            {
                return NotFound();
            }

            _datFitBase.ExeWorkout.Remove(deletedExeWorkout);
            await _datFitBase.SaveChangesAsync();
            return Ok();

        }
    }
}
