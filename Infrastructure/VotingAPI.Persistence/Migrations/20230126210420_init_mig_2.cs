using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VoterId",
                schema: "dbo",
                table: "Votes",
                newName: "Students");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                schema: "dbo",
                table: "Votes",
                newName: "Candidates");

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
                name: "IX_Votes_Students",
                schema: "dbo",
                table: "Votes",
                column: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                column: "VotingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_StudentId",
                schema: "dbo",
                table: "Candidates",
                column: "StudentId",
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
                name: "FK_Votes_Students_Candidates",
                schema: "dbo",
                table: "Votes",
                column: "Candidates",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Students_Students",
                schema: "dbo",
                table: "Votes",
                column: "Students",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_VotingPeriods_ElectionTypes_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods",
                column: "ElectionTypeId",
                principalSchema: "dbo",
                principalTable: "ElectionTypes",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Students_StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_Candidates",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_Students",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingPeriods_ElectionTypes_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_Candidates_WinnerId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropForeignKey(
                name: "FK_Votings_VotingPeriods_VotingPeriodId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropIndex(
                name: "IX_Votings_VotingPeriodId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropIndex(
                name: "IX_Votings_WinnerId",
                schema: "dbo",
                table: "Votings");

            migrationBuilder.DropIndex(
                name: "IX_VotingPeriods_ElectionTypeId",
                schema: "dbo",
                table: "VotingPeriods");

            migrationBuilder.DropIndex(
                name: "IX_Votes_Candidates",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_Students",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Students",
                schema: "dbo",
                table: "Votes",
                newName: "VoterId");

            migrationBuilder.RenameColumn(
                name: "Candidates",
                schema: "dbo",
                table: "Votes",
                newName: "CandidateId");
        }
    }
}
