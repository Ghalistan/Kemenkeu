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
    public class ProyekController : ControllerBase
    {
        private readonly KemenkeuContext _context;

        public ProyekController(KemenkeuContext context)
        {
            _context = context;
        }

        // GET: api/Proyek
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyek>>> GetProyek()
        {
            return await _context.Proyek.ToListAsync();
        }

        // GET: api/Proyek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyek>> GetProyek(int id)
        {
            var proyek = await _context.Proyek.FindAsync(id);

            if (proyek == null)
            {
                return NotFound();
            }

            return proyek;
        }

        // PUT: api/Proyek/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyek(int id, Proyek proyek)
        {
            if (id != proyek.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyekExists(id))
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

        // POST: api/Proyek
        [HttpPost]
        public async Task<ActionResult<Proyek>> PostProyek(Proyek proyek)
        {
            _context.Proyek.Add(proyek);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProyekExists(proyek.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProyek", new { id = proyek.Id }, proyek);
        }

        // DELETE: api/Proyek/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proyek>> DeleteProyek(int id)
        {
            var proyek = await _context.Proyek.FindAsync(id);
            if (proyek == null)
            {
                return NotFound();
            }

            _context.Proyek.Remove(proyek);
            await _context.SaveChangesAsync();

            return proyek;
        }

        private bool ProyekExists(int id)
        {
            return _context.Proyek.Any(e => e.Id == id);
        }
    }
}
