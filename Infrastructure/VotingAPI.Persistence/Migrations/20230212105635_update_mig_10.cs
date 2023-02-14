using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_Students",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_Students",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "Students",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Students_VoterId",
                schema: "dbo",
                table: "Votes",
                column: "VoterId",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Students_VoterId",
                schema: "dbo",
                table: "Votes");

            migrationBuilder.AddColumn<int>(
                name: "Students",
                schema: "dbo",
                table: "Votes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_Students",
                schema: "dbo",
                table: "Votes",
                column: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Students_Students",
                schema: "dbo",
                table: "Votes",
                column: "Students",
                principalSchema: "dbo",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
