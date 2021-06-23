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
    public class ExeController : ControllerBase
    {
        private readonly FitAppDbContext _datFitBase;

        public ExeController(FitAppDbContext fitDB)
        {
            _datFitBase = fitDB;
        }

        [HttpGet("exelist")]
        public async Task<IActionResult> GetExes()
        {
            var exeList = await _datFitBase.Exe.ToListAsync();
            return Ok(exeList);
        }

        [HttpGet("exelistbyuser/{fitAppUserId}")]
        public async Task<IActionResult> GetExesByUser(string fitAppUserId)
        {
            var exesByUser = await _datFitBase.Exe.Where(t => t.FitAppUserId == fitAppUserId)
                .ToListAsync();
            if (exesByUser == null || exesByUser.Count == 0)
            {
                exesByUser = new List<Exe>();
                return Ok(exesByUser);
            }
            return Ok(exesByUser);
        }

        [HttpGet("exelistbyuserandworkout/{fitAppUserId}/{exeWorkoutId:int}")]
        public async Task<IActionResult> GetExesByUserandWorkout(string fitAppUserId, int exeWorkoutId)
        {

            var exesByUserAndWorkout = await _datFitBase.Exe.Where(t => t.FitAppUserId == fitAppUserId)
                .Where(i => i.ExeWorkoutExeWorkoutId == exeWorkoutId)
                .ToListAsync();

            if (exesByUserAndWorkout == null || exesByUserAndWorkout.Count == 0)
            {
                exesByUserAndWorkout = new List<Exe>();
                return Ok(exesByUserAndWorkout);
            }
            return Ok(exesByUserAndWorkout);
        }

        [HttpGet("singleexe/{singleExeId:int}")]
        public async Task<IActionResult> GetExe(int singleExeId)
        {
            var exe = await _datFitBase.Exe.FindAsync(singleExeId);
            if (exe == null)
            {
                return NotFound();
            }
            return Ok(exe);
        }

        [HttpPost("createexe")]
        public async Task<IActionResult> createExe([FromBody] Exe newExe)
        {
            await _datFitBase.Exe.AddAsync(newExe);
            await _datFitBase.SaveChangesAsync();
            return Ok(newExe);
        }

        [HttpPut("updateexe/{updatedExeId:int}")]
        public async Task<IActionResult> updateExe(int updatedExeId, [FromBody] Exe updatedExe)
        {
            if (updatedExeId != updatedExe.ExeId) return BadRequest();
            _datFitBase.Entry(updatedExe).State = EntityState.Modified;
            try
            {
                await _datFitBase.SaveChangesAsync();
                return Ok(updatedExe);
            }
            catch
            {
                if (await _datFitBase.Exe.FindAsync(updatedExeId) == null)
                {
                    return NotFound();
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("deleteexe/{deletedExeId:int}")]
        public async Task<IActionResult> deleteExe(int deletedExeId)
        {
            var deletedExe = await _datFitBase.Exe.FindAsync(deletedExeId);
            if (deletedExe == null)
            {
                return NotFound();
            }

            _datFitBase.Exe.Remove(deletedExe);
            await _datFitBase.SaveChangesAsync();
            return Ok();

        }
    }
}
