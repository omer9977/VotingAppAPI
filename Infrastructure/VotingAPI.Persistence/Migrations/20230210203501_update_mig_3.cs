using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatemig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTypes_FileTypeId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FileTypeId",
                schema: "dbo",
                table: "Files");

            migrationBuilder.AlterColumn<short>(
                name: "FileTypeId",
                schema: "dbo",
                table: "Files",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "FileTypeId1",
                schema: "dbo",
                table: "Files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileTypeId1",
                schema: "dbo",
                table: "Files",
                column: "FileTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTypes_FileTypeId1",
                schema: "dbo",
                table: "Files",
                column: "FileTypeId1",
                principalSchema: "dbo",
                principalTable: "FileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTypes_FileTypeId1",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FileTypeId1",
                schema: "dbo",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileTypeId1",
                schema: "dbo",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "FileTypeId",
                schema: "dbo",
                table: "Files",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileTypeId",
                schema: "dbo",
                table: "Files",
                column: "FileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTypes_FileTypeId",
                schema: "dbo",
                table: "Files",
                column: "FileTypeId",
                principalSchema: "dbo",
                principalTable: "FileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
