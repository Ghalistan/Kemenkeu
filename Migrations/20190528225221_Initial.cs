using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kemenkeu.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Berita",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Judul_Berita = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Detail_Berita = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    Tanggal_Ditambahkan = table.Column<DateTime>(type: "date", nullable: false),
                    Tanggal_Diedit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berita", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PJPK",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Judul = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    Tanggal_Ditambahkan = table.Column<DateTime>(type: "date", nullable: false),
                    Tanggal_Diedit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PJPK", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proyek",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Nama_Proyek = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nilai = table.Column<int>(nullable: false),
                    PJPK = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Fasilitas = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Lokasi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Sektor = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Tanggal_Ditambahkan = table.Column<DateTime>(type: "date", nullable: false),
                    Tanggal_Diedit = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyek", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Detail_Proyek",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Detail_Proyek = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Proyek", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detail_Proyek_Proyek",
                        column: x => x.id,
                        principalTable: "Proyek",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berita");

            migrationBuilder.DropTable(
                name: "Detail_Proyek");

            migrationBuilder.DropTable(
                name: "PJPK");

            migrationBuilder.DropTable(
                name: "Proyek");
        }
    }
}
