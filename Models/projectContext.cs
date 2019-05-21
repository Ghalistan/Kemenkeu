using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemenkeu.Models
{
    public class projectContext : DbContext
    {
        public projectContext(DbContextOptions<projectContext> options)
            : base(options)
        { }

        public DbSet<project> projectItems { get; set; }
        public DbSet<BeritaItem> BeritaItems { get; set; }
    }
}
