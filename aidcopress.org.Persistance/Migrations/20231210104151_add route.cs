using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class addroute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_busServiceRoutes",
                table: "busServiceRoutes");

            migrationBuilder.RenameTable(
                name: "busServiceRoutes",
                newName: "BusServiceRoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusServiceRoutes",
                table: "BusServiceRoutes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusServiceRoutes",
                table: "BusServiceRoutes");

            migrationBuilder.RenameTable(
                name: "BusServiceRoutes",
                newName: "busServiceRoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_busServiceRoutes",
                table: "busServiceRoutes",
                column: "Id");
        }
    }
}
