using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Token_TokenId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Token",
                table: "Token");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Tokens",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tokens",
                schema: "dbo",
                table: "Tokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tokens_TokenId",
                schema: "dbo",
                table: "Students",
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
                name: "FK_Students_Tokens_TokenId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tokens",
                schema: "dbo",
                table: "Tokens");

            migrationBuilder.RenameTable(
                name: "Tokens",
                schema: "dbo",
                newName: "Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Token",
                table: "Token",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Token_TokenId",
                schema: "dbo",
                table: "Students",
                column: "TokenId",
                principalTable: "Token",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
