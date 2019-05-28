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

        public virtual DbSet<Berita> Berita { get; set; }
        public virtual DbSet<DetailProyek> DetailProyek { get; set; }
        public virtual DbSet<Pjpk> Pjpk { get; set; }
        public virtual DbSet<Proyek> Proyek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Berita>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DetailBerita)
                    .IsRequired()
                    .HasColumnName("Detail_Berita")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.JudulBerita)
                    .IsRequired()
                    .HasColumnName("Judul_Berita")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalDiedit)
                    .HasColumnName("Tanggal_Diedit")
                    .HasColumnType("date");

                entity.Property(e => e.TanggalDitambahkan)
                    .HasColumnName("Tanggal_Ditambahkan")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<DetailProyek>(entity =>
            {
                entity.ToTable("Detail_Proyek");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DetailProyek1)
                    .IsRequired()
                    .HasColumnName("Detail_Proyek")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.DetailProyek)
                    .HasForeignKey<DetailProyek>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_Proyek_Proyek");
            });

            modelBuilder.Entity<Pjpk>(entity =>
            {
                entity.ToTable("PJPK");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Judul)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalDiedit)
                    .HasColumnName("Tanggal_Diedit")
                    .HasColumnType("date");

                entity.Property(e => e.TanggalDitambahkan)
                    .HasColumnName("Tanggal_Ditambahkan")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Proyek>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fasilitas)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lokasi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaProyek)
                    .IsRequired()
                    .HasColumnName("Nama_Proyek")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pjpk)
                    .IsRequired()
                    .HasColumnName("PJPK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sektor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalDiedit)
                    .HasColumnName("Tanggal_Diedit")
                    .HasColumnType("date");

                entity.Property(e => e.TanggalDitambahkan)
                    .HasColumnName("Tanggal_Ditambahkan")
                    .HasColumnType("date");
            });
        }
    }
}
