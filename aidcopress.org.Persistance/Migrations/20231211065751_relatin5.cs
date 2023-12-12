using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aidcopress.org.Persistence.Migrations
{
    public partial class relatin5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_BusServiceRoutes_BusServiceRouteId",
                table: "Personels");

            migrationBuilder.AlterColumn<int>(
                name: "BusServiceRouteId",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "BusServiceRouteId",
                table: "Personels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_BusServiceRoutes_BusServiceRouteId",
                table: "Personels",
                column: "BusServiceRouteId",
                principalTable: "BusServiceRoutes",
                principalColumn: "Id");
        }
    }
}
