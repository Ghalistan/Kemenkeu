using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemenkeu.Models
{
    public class BeritaContext : DbContext
    {
        public BeritaContext(DbContextOptions<BeritaContext> options)
            : base(options)
        {
        }

        public DbSet<BeritaItem> BeritaItems { get; set; }
    }
}
