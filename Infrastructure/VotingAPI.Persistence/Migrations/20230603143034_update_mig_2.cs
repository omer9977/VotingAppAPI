using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Students_StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "StudentId",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Candidates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                schema: "dbo",
                table: "Candidates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                schema: "dbo",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_StudentId",
                schema: "dbo",
                table: "Candidates",
                column: "StudentId");

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
                name: "FK_Students_Users_UserId",
                schema: "dbo",
                table: "Students",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
