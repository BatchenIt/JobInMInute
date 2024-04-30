using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobInMinuteServer.Migrations
{
    /// <inheritdoc />
    public partial class candidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Candidats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidats_UserId",
                table: "Candidats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidats_Users_UserId",
                table: "Candidats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidats_Users_UserId",
                table: "Candidats");

            migrationBuilder.DropIndex(
                name: "IX_Candidats_UserId",
                table: "Candidats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Candidats");
        }
    }
}
