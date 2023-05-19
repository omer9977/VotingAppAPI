using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Students_StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_Candidates_WinnerId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FileTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VotingPeriods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ElectionTypes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Votings_VotingPeriodId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropIndex(
                name: "IX_Votings_WinnerId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VoterId_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "VotingPeriodId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "WinnerId",
                schema: "dbo",
                table: "Votings",
                newName: "FacultyId");

            migrationBuilder.RenameColumn(
                name: "VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                newName: "ElectionId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Votings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "Votings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Votings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "Votings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "StudentId",
                schema: "dbo",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                schema: "dbo",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                schema: "dbo",
                table: "Departments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                schema: "dbo",
                table: "Candidates",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ApproveStatus",
                schema: "dbo",
                table: "Candidates",
                type: "text",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                schema: "dbo",
                table: "Candidates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                schema: "dbo",
                table: "Candidates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Faculties",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CandidateId = table.Column<int>(type: "integer", nullable: false),
                    ElectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionId",
                schema: "dbo",
                table: "Votes",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ElectionId",
                schema: "dbo",
                table: "Candidates",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_StudentId1",
                schema: "dbo",
                table: "Candidates",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Students_StudentId1",
                schema: "dbo",
                table: "Candidates",
                column: "StudentId1",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Votings_ElectionId",
                schema: "dbo",
                table: "Candidates",
                column: "ElectionId",
                principalSchema: "dbo",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Votings_ElectionId",
                schema: "dbo",
                table: "Votes",
                column: "ElectionId",
                principalSchema: "dbo",
                principalTable: "Votings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Students_StudentId1",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Votings_ElectionId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Votings_ElectionId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "Faculties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Winners",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ElectionId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_ElectionId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_StudentId1",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserRole",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                schema: "dbo",
                table: "Votings",
                newName: "WinnerId");

            migrationBuilder.RenameColumn(
                name: "ElectionId",
                schema: "dbo",
                table: "Votes",
                newName: "VotingPeriodId");

            migrationBuilder.AddColumn<int>(
                name: "VotingPeriodId",
                schema: "dbo",
                table: "Votings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "dbo",
                table: "Candidates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<short>(
                name: "ApproveStatus",
                schema: "dbo",
                table: "Candidates",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ApplicationDate",
                schema: "dbo",
                table: "Candidates",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "ElectionTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ApprovedStatus = table.Column<short>(type: "smallint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileTypeId = table.Column<short>(type: "smallint", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotingPeriods",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ElectionTypeId = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingPeriods_ElectionTypes_ElectionTypeId",
                        column: x => x.ElectionTypeId,
                        principalSchema: "dbo",
                        principalTable: "ElectionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votings_VotingPeriodId",
                schema: "dbo",
                table: "Votings",
                column: "VotingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Votings_WinnerId",
                schema: "dbo",
                table: "Votings",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                columns: new[] { "VoterId", "VotingPeriodId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                column: "VotingPeriodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "dbo",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTypes_TypeName",
                schema: "dbo",
                table: "ElectionTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                schema: "dbo",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTypes_Name",
                schema: "dbo",
                table: "FileTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods",
                column: "ElectionTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Students_StudentId",
                schema: "dbo",
                table: "Candidates",
                column: "StudentId",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                schema: "dbo",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                column: "VotingPeriodId",
                principalSchema: "dbo",
                principalTable: "VotingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_Candidates_WinnerId",
                schema: "dbo",
                table: "Votings",
                column: "WinnerId",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votings_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votings",
                column: "VotingPeriodId",
                principalSchema: "dbo",
                principalTable: "VotingPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
