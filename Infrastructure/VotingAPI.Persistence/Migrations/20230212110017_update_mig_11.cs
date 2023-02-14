using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId_VotingPeriodId",
                schema: "dbo",
                table: "Votes",
                columns: new[] { "VoterId", "VotingPeriodId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Votes_VoterId_VotingPeriodId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VoterId",
                schema: "dbo",
                table: "Votes",
                column: "VoterId",
                unique: true);
        }
    }
}
