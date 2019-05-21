using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kemenkeu.Models
{
    public partial class KemenkeuContext : DbContext
    {
        public KemenkeuContext()
        {
        }

        public KemenkeuContext(DbContextOptions<KemenkeuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pjpk> Pjpk { get; set; }
        public virtual DbSet<Proyek> Proyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Pjpk>(entity =>
            {
                entity.ToTable("PJPK");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proyek>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DetailProyek)
                    .IsRequired()
                    .HasColumnName("Detail_Proyek")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kota)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaProyek)
                    .IsRequired()
                    .HasColumnName("Nama_Proyek")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NilaiProyek).HasColumnName("Nilai_Proyek");

                entity.Property(e => e.Provinsi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sektor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusProyek)
                    .IsRequired()
                    .HasColumnName("Status_Proyek")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
