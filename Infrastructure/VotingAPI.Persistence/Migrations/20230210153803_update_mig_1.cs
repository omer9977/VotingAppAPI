using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Candidates_CandidateId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CandidateId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                schema: "dbo",
                table: "Files",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                schema: "dbo",
                table: "Files",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                schema: "dbo",
                table: "Files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CandidateId",
                schema: "dbo",
                table: "Files",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Candidates_CandidateId",
                schema: "dbo",
                table: "Files",
                column: "CandidateId",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
