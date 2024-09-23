using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV130 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FileId",
                table: "NhanVien",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "CaiDatTongThe",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "LinkAnh",
                table: "CaiDatTongThe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "CaiDatChiTiet",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_FileId",
                table: "NhanVien",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_NhanVien_FileUpload_FileId",
                table: "NhanVien",
                column: "FileId",
                principalTable: "FileUpload",
                principalColumn: "Id");
            migrationBuilder.Sql(@"update CaiDatTongThe set FileId = null where FileId = 0");
            migrationBuilder.Sql(@"update CaiDatChiTiet set FileId = null where FileId = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhanVien_FileUpload_FileId",
                table: "NhanVien");

            migrationBuilder.DropIndex(
                name: "IX_NhanVien_FileId",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "LinkAnh",
                table: "CaiDatTongThe");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "CaiDatTongThe",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "CaiDatChiTiet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
