using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class addservicerouteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Service_route_id",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Service_route_id",
                table: "Personels");
        }
    }
}
