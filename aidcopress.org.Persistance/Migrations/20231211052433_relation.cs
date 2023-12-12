using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusServiceRouteId",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BusServiceRouteId",
                table: "Personels",
                column: "BusServiceRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_BusServiceRoutes_BusServiceRouteId",
                table: "Personels",
                column: "BusServiceRouteId",
                principalTable: "BusServiceRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_BusServiceRoutes_BusServiceRouteId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_BusServiceRouteId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "BusServiceRouteId",
                table: "Personels");
        }
    }
}
