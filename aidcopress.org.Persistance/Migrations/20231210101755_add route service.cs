using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class addrouteservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rahkaran_cod",
                table: "Personels",
                newName: "Rahkaran_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rahkaran_code",
                table: "Personels",
                newName: "Rahkaran_cod");
        }
    }
}
