using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalRecordFiles_Candidates_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TranscriptFiles_Candidates_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropTable(
                name: "ProfilePhotos",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropIndex(
                name: "IX_TranscriptFiles_Path",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropIndex(
                name: "IX_CriminalRecordFiles_Path",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "ApprovedStatus",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropColumn(
                name: "Storage",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropColumn(
                name: "ApprovedStatus",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "Storage",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    CandidateId = table.Column<int>(type: "integer", nullable: false),
                    FileTypeId = table.Column<int>(type: "integer", nullable: false),
                    ApprovedStatus = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "dbo",
                        principalTable: "Candidates",
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

            migrationBuilder.CreateIndex(
                name: "IX_Files_CandidateId",
                schema: "dbo",
                table: "Files",
                column: "CandidateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalRecordFiles_Files_Id",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranscriptFiles_Files_Id",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalRecordFiles_Files_Id",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TranscriptFiles_Files_Id",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FileTypes",
                schema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "ApprovedStatus",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                schema: "dbo",
                table: "TranscriptFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<short>(
                name: "ApprovedStatus",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                schema: "dbo",
                table: "CriminalRecordFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProfilePhotos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CandidateId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePhotos_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalSchema: "dbo",
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranscriptFiles_Path",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalRecordFiles_Path",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhotos_CandidateId",
                schema: "dbo",
                table: "ProfilePhotos",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalRecordFiles_Candidates_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "CandidateId",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranscriptFiles_Candidates_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "CandidateId",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
