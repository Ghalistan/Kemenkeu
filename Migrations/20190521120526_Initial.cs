using Microsoft.EntityFrameworkCore.Migrations;

namespace Kemenkeu.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PJPK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PJPK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nama_Proyek = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nilai_Proyek = table.Column<int>(nullable: false),
                    Sektor = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Detail_Proyek = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Provinsi = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Kota = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Status_Proyek = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PJPK");

            migrationBuilder.DropTable(
                name: "Proyek");
        }
    }
}
