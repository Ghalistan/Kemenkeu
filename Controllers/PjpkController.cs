using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kemenkeu.Models;

namespace Kemenkeu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PJPKController : ControllerBase
    {
        private readonly KemenkeuContext _context;

        public PJPKController(KemenkeuContext context)
        {
            _context = context;
        }

        // GET: api/PJPK
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pjpk>>> GetPjpk()
        {
            return await _context.Pjpk.ToListAsync();
        }

        // GET: api/PJPK/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pjpk>> GetPjpk(int id)
        {
            var pjpk = await _context.Pjpk.FindAsync(id);

            if (pjpk == null)
            {
                return NotFound();
            }

            return pjpk;
        }

        // PUT: api/PJPK/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPjpk(int id, Pjpk pjpk)
        {
            if (id != pjpk.Id)
            {
                return BadRequest();
            }

            _context.Entry(pjpk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PjpkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PJPK
        [HttpPost]
        public async Task<ActionResult<Pjpk>> PostPjpk(Pjpk pjpk)
        {
            _context.Pjpk.Add(pjpk);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PjpkExists(pjpk.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPjpk", new { id = pjpk.Id }, pjpk);
        }

        // DELETE: api/PJPK/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pjpk>> DeletePjpk(int id)
        {
            var pjpk = await _context.Pjpk.FindAsync(id);
            if (pjpk == null)
            {
                return NotFound();
            }

            _context.Pjpk.Remove(pjpk);
            await _context.SaveChangesAsync();

            return pjpk;
        }

        private bool PjpkExists(int id)
        {
            return _context.Pjpk.Any(e => e.Id == id);
        }
    }
}
