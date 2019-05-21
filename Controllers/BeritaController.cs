using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kemenkeu.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kemenkeu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeritaController : Controller
    {
        private readonly projectContext _context;

        public BeritaController(projectContext context)
        {
            _context = context;

            if (_context.BeritaItems.Count() == 0)
            {
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Berita 1", DetailBerita = "Detail 1" });
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Berita 2", DetailBerita = "Detail 2" });
                _context.BeritaItems.Add(new BeritaItem { NamaBerita = "Berita 3", DetailBerita = "Detail 3" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeritaItem>>> GetBeritaItems()
        {
            return await _context.BeritaItems.ToListAsync();
        }
    }
}
