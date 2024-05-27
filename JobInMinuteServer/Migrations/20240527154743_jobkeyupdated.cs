using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobInMinuteServer.Migrations
{
    /// <inheritdoc />
    public partial class jobkeyupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePreferedCities_Candidats_CandidateID1",
                table: "CandidatePreferedCities");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidats_Users_UserId",
                table: "Candidats");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CandidatePreferedCities_CandidatePreferedCitiesCandidateID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Users_UserId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_CandidateJobs_CandidateJobsCandidateID",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CandidateJobsCandidateID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CandidatePreferedCitiesCandidateID",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePreferedCities",
                table: "CandidatePreferedCities");

            migrationBuilder.DropColumn(
                name: "CandidateJobsCandidateID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CandidatePreferedCitiesCandidateID",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Jobs",
                newName: "CityCode");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Employers",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employers",
                newName: "EmployerID");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_UserId",
                table: "Employers",
                newName: "IX_Employers_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Candidats",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Candidats",
                newName: "CandidateID");

            migrationBuilder.RenameIndex(
                name: "IX_Candidats_UserId",
                table: "Candidats",
                newName: "IX_Candidats_UserID");

            migrationBuilder.RenameColumn(
                name: "CandidateID1",
                table: "CandidatePreferedCities",
                newName: "CityCode");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePreferedCities_CandidateID1",
                table: "CandidatePreferedCities",
                newName: "IX_CandidatePreferedCities_CityCode");

            migrationBuilder.AlterColumn<int>(
                name: "CityCode",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CityCode",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Businessfield",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "CandidatePreferedCities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CandidatePreferedCities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "CandidateJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePreferedCities",
                table: "CandidatePreferedCities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CityCode1",
                table: "Jobs",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePreferedCities_CandidateID",
                table: "CandidatePreferedCities",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobs_JobID",
                table: "CandidateJobs",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateJobs_Jobs_JobID",
                table: "CandidateJobs",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePreferedCities_Candidats_CandidateID",
                table: "CandidatePreferedCities",
                column: "CandidateID",
                principalTable: "Candidats",
                principalColumn: "CandidateID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePreferedCities_Cities_CityCode",
                table: "CandidatePreferedCities",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "CityCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidats_Users_UserID",
                table: "Candidats",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Users_UserID",
                table: "Employers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Cities_CityCode1",
                table: "Jobs",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "CityCode",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateJobs_Jobs_JobID",
                table: "CandidateJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePreferedCities_Candidats_CandidateID",
                table: "CandidatePreferedCities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePreferedCities_Cities_CityCode",
                table: "CandidatePreferedCities");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidats_Users_UserID",
                table: "Candidats");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Users_UserID",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Cities_CityCode1",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CityCode1",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePreferedCities",
                table: "CandidatePreferedCities");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePreferedCities_CandidateID",
                table: "CandidatePreferedCities");

            migrationBuilder.DropIndex(
                name: "IX_CandidateJobs_JobID",
                table: "CandidateJobs");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Businessfield",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CandidatePreferedCities");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "CandidateJobs");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "Jobs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Employers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "EmployerID",
                table: "Employers",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_UserID",
                table: "Employers",
                newName: "IX_Employers_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Candidats",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CandidateID",
                table: "Candidats",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Candidats_UserID",
                table: "Candidats",
                newName: "IX_Candidats_UserId");

            migrationBuilder.RenameColumn(
                name: "CityCode",
                table: "CandidatePreferedCities",
                newName: "CandidateID1");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePreferedCities_CityCode",
                table: "CandidatePreferedCities",
                newName: "IX_CandidatePreferedCities_CandidateID1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateJobsCandidateID",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidatePreferedCitiesCandidateID",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateID",
                table: "CandidatePreferedCities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePreferedCities",
                table: "CandidatePreferedCities",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CandidateJobsCandidateID",
                table: "Jobs",
                column: "CandidateJobsCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CandidatePreferedCitiesCandidateID",
                table: "Cities",
                column: "CandidatePreferedCitiesCandidateID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePreferedCities_Candidats_CandidateID1",
                table: "CandidatePreferedCities",
                column: "CandidateID1",
                principalTable: "Candidats",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidats_Users_UserId",
                table: "Candidats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CandidatePreferedCities_CandidatePreferedCitiesCandidateID",
                table: "Cities",
                column: "CandidatePreferedCitiesCandidateID",
                principalTable: "CandidatePreferedCities",
                principalColumn: "CandidateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Users_UserId",
                table: "Employers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_CandidateJobs_CandidateJobsCandidateID",
                table: "Jobs",
                column: "CandidateJobsCandidateID",
                principalTable: "CandidateJobs",
                principalColumn: "CandidateID");
        }
    }
}
