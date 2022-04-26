using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class AddIsDriverColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDriver",
                table: "Orderers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IsDriver",
                table: "Orderers");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_UserId",
                table: "Passengers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");
        }
    }
}
