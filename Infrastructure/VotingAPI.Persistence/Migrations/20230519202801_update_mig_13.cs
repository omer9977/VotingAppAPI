using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                schema: "dbo",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
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
                name: "AccessToken",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AccessToken",
                schema: "dbo",
                table: "Candidates");
        }
    }
}
