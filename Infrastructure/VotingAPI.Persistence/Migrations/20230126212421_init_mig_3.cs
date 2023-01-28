using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initmig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_Candidates",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Votes_Candidates",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.RenameColumn(
                name: "Candidates",
                schema: "dbo",
                table: "Votes",
                newName: "VoterId");

            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                schema: "dbo",
                table: "Votes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods",
                column: "ElectionTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CandidateId",
                schema: "dbo",
                table: "Votes",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes",
                column: "VoterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                column: "VotingPeriodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "CandidateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Students_CandidateId",
                schema: "dbo",
                table: "Votes",
                column: "CandidateId",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_CandidateId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Votes_CandidateId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles");

            migrationBuilder.DropIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "VoterId",
                schema: "dbo",
                table: "Votes",
                newName: "Candidates");

            migrationBuilder.CreateIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods",
                column: "ElectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_Candidates",
                schema: "dbo",
                table: "Votes",
                column: "Candidates");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                column: "VotingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TranscriptFiles_CandidateId",
                schema: "dbo",
                table: "TranscriptFiles",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalRecordFiles_CandidateId",
                schema: "dbo",
                table: "CriminalRecordFiles",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Students_Candidates",
                schema: "dbo",
                table: "Votes",
                column: "Candidates",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
