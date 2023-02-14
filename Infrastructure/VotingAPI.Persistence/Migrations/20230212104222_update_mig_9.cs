using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_CandidateId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Candidates_CandidateId",
                schema: "dbo",
                table: "Votes",
                column: "CandidateId",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Candidates_CandidateId",
                schema: "dbo",
                table: "Votes");

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
    }
}
