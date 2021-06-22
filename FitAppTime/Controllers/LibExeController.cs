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
    public class LibExeController : ControllerBase
    {
        private readonly FitAppDbContext _datFitBase;

        public LibExeController(FitAppDbContext fitDB)
        {
            _datFitBase = fitDB;
        }

        [HttpGet("libexelist")]
        public async Task<IActionResult> GetLibExes() 
        {
            var libExeList = await _datFitBase.LibExe.ToListAsync();
            return Ok(libExeList);
        }

        [HttpGet("libexesbyuser/{fitAppUserId}")]
        public async Task<IActionResult> GetLibExesByUser(string fitAppUserId)
        {
            
            var libExesByUser = await _datFitBase.LibExe.Where(t => t.FitAppUserId == fitAppUserId).ToListAsync();
            //var expensesByMonthList = await _datExpBase.Expenses.Where(t => t.MonthYear == targetMonth).ToListAsync();
            if (libExesByUser == null || libExesByUser.Count == 0)
            {
                libExesByUser = new List<LibExe>();
                return Ok(libExesByUser);
            }
            return Ok(libExesByUser);
        }

        [HttpGet("singlelibexe/{singleLibExeId:int}")]
        public async Task<IActionResult> GetSingleLibExe(int singleLibExeId)
        {
            var libExe = await _datFitBase.LibExe.FindAsync(singleLibExeId);
            if (libExe == null)
            {
                return NotFound();
            }
            return Ok(libExe);
        }

        [HttpPost("createlibexe")]
        public async Task<IActionResult> createLibExe([FromBody] LibExe newLibExe)
        {
            //newExpense.MonthYear = newExpense.DateSpent.ToString("yyyy-MM");
            await _datFitBase.LibExe.AddAsync(newLibExe);
            await _datFitBase.SaveChangesAsync();
            return Ok(newLibExe);
        }

        [HttpPut("updatelibexe/{updatedLibExeId:int}")]
        public async Task<IActionResult> updateLibExe(int updatedLibExeId, [FromBody] LibExe updatedLibExe)
        {
            if (updatedLibExeId != updatedLibExe.LibExeId) return BadRequest();
            _datFitBase.Entry(updatedLibExe).State = EntityState.Modified;
            try
            {
                await _datFitBase.SaveChangesAsync();
                return Ok(updatedLibExe);
            }
            catch
            {
                if (await _datFitBase.LibExe.FindAsync(updatedLibExeId) == null)
                {
                    return NotFound();
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("deletelibexe/{deletedLibExeId:int}")]
        public async Task<IActionResult> deleteLibExe(int deletedLibExeId)
        {
            var deletedLibExe = await _datFitBase.LibExe.FindAsync(deletedLibExeId);
            if (deletedLibExe == null)
            {
                return NotFound();
            }

            _datFitBase.LibExe.Remove(deletedLibExe);
            await _datFitBase.SaveChangesAsync();
            return Ok();

        }


    }
}
