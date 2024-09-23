using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV124 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "ChiTietCoSoVatChat",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCoSoVatChat_FileId",
                table: "ChiTietCoSoVatChat",
                column: "FileId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ChiTietCoSoVatChat_FileUpload_FileId",
            //    table: "ChiTietCoSoVatChat",
            //    column: "FileId",
            //    principalTable: "FileUpload",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ChiTietCoSoVatChat_FileUpload_FileId",
            //    table: "ChiTietCoSoVatChat");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCoSoVatChat_FileId",
                table: "ChiTietCoSoVatChat");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "ChiTietCoSoVatChat",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
