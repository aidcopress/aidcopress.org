using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class relation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusServiceRoutes_Personels_PersonelId",
                table: "BusServiceRoutes");

            migrationBuilder.DropIndex(
                name: "IX_BusServiceRoutes_PersonelId",
                table: "BusServiceRoutes");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "BusServiceRoutes");

            migrationBuilder.AddColumn<int>(
                name: "BusServiceRouteId",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BusServiceRouteId",
                table: "Personels",
                column: "BusServiceRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_BusServiceRoutes_BusServiceRouteId",
                table: "Personels",
                column: "BusServiceRouteId",
                principalTable: "BusServiceRoutes",
                principalColumn: "Id");
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

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "BusServiceRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceRoutes_PersonelId",
                table: "BusServiceRoutes",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServiceRoutes_Personels_PersonelId",
                table: "BusServiceRoutes",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
