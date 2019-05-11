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
    public class projectController : ControllerBase
    {
        private readonly projectContext _context;

        public projectController(projectContext context)
        {
            _context = context;

            if (_context.projectItems.Count() == 0)
            {
                _context.projectItems.Add(new project { NamaProyek = "Test Nama Proyek", detailProyek = "Test Detail Proyek" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<project>>> GetprojectItems()
        {
            return await _context.projectItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<project>> GetprojectItem(long id)
        {
            var projectItem = await _context.projectItems.FindAsync(id);

            if (projectItem == null)
            {
                return NotFound();
            }

            return projectItem;
        }
    }
}
