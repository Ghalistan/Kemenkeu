using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kemenkeu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kemenkeu.Controllers
{
    [Route("api/[controller]")]
    public class BeritaController : Controller
    {
        private readonly BeritaContext _context;

        public BeritaController(BeritaContext context)
        {
            _context = context;

            if (_context.BeritaItems.Count() == 0)
            {
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Test besrita 1", DetailBerita = "detail berita 1" });
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Test besrita 2", DetailBerita = "detail berita 2" });
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Test besrita 3", DetailBerita = "detail berita 3" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeritaItem>>> GetBeritaItems()
        {
            return await _context.BeritaItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BeritaItem>> GetBeritaItem(long id)
        {
            var BeritaItem = await _context.BeritaItems.FindAsync(id);

            if(BeritaItem == null)
            {
                return NotFound();
            }

            return BeritaItem;
        }
    }
}
