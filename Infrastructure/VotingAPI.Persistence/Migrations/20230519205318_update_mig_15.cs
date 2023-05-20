using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "TokenId",
                schema: "dbo",
                table: "Candidates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TokenId",
                schema: "dbo",
                table: "Candidates",
                column: "TokenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Tokens_TokenId",
                schema: "dbo",
                table: "Candidates",
                column: "TokenId",
                principalSchema: "dbo",
                principalTable: "Tokens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Tokens_TokenId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_TokenId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TokenId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                schema: "dbo",
                table: "Candidates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
