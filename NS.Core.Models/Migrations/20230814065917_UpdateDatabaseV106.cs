using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiBaiViet",
                table: "TinTuc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "MenuConfig",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "MenuConfig",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CauLacBoId",
                table: "FileUpload",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkFile",
                table: "FileUpload",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CauLacBo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCauLacBo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenCauLacBoTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoBuoiHoc = table.Column<int>(type: "int", nullable: false),
                    HocPhi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauLacBo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileUpload_CauLacBoId",
                table: "FileUpload",
                column: "CauLacBoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileUpload_CauLacBo_CauLacBoId",
                table: "FileUpload",
                column: "CauLacBoId",
                principalTable: "CauLacBo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileUpload_CauLacBo_CauLacBoId",
                table: "FileUpload");

            migrationBuilder.DropTable(
                name: "CauLacBo");

            migrationBuilder.DropIndex(
                name: "IX_FileUpload_CauLacBoId",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "LoaiBaiViet",
                table: "TinTuc");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "MenuConfig");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "MenuConfig");

            migrationBuilder.DropColumn(
                name: "CauLacBoId",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "LinkFile",
                table: "FileUpload");
        }
    }
}
