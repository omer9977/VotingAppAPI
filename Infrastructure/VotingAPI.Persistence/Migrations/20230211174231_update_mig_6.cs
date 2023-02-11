using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId");
        }
    }
}
