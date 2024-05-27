using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobInMinuteServer.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Cities_CityCode",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CityCode",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "CityCode1",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityCode1",
                table: "Jobs",
                column: "CityCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Cities_CityCode1",
                table: "Jobs",
                column: "CityCode1",
                principalTable: "Cities",
                principalColumn: "CityCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Cities_CityCode1",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CityCode1",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CityCode1",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityCode",
                table: "Jobs",
                column: "CityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Cities_CityCode",
                table: "Jobs",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "CityCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
