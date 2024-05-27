using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobInMinuteServer.Migrations
{
    /// <inheritdoc />
    public partial class employer22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Jobs",
                newName: "SkillsRequired");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "SkillsRequired",
                table: "Jobs",
                newName: "Adress");
        }
    }
}
