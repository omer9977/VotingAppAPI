using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "dbo",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "dbo",
                table: "Students",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "dbo",
                table: "Students");
        }
    }
}
