using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV136 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "CaiDatEmail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HeDaoTaoId",
                table: "CaiDatEmail",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "KhoiId",
                table: "CaiDatEmail",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "XacThucTaiKhoan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaiKhoanId = table.Column<long>(type: "bigint", nullable: false),
                    NgayYeuCau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoaiXacThucTaiKhoan = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XacThucTaiKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XacThucTaiKhoan_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatEmail_HeDaoTaoId",
                table: "CaiDatEmail",
                column: "HeDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatEmail_KhoiId",
                table: "CaiDatEmail",
                column: "KhoiId");

            migrationBuilder.CreateIndex(
                name: "IX_XacThucTaiKhoan_TaiKhoanId",
                table: "XacThucTaiKhoan",
                column: "TaiKhoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaiDatEmail_HeDaoTao_HeDaoTaoId",
                table: "CaiDatEmail",
                column: "HeDaoTaoId",
                principalTable: "HeDaoTao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaiDatEmail_Khoi_KhoiId",
                table: "CaiDatEmail",
                column: "KhoiId",
                principalTable: "Khoi",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaiDatEmail_HeDaoTao_HeDaoTaoId",
                table: "CaiDatEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_CaiDatEmail_Khoi_KhoiId",
                table: "CaiDatEmail");

            migrationBuilder.DropTable(
                name: "XacThucTaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_CaiDatEmail_HeDaoTaoId",
                table: "CaiDatEmail");

            migrationBuilder.DropIndex(
                name: "IX_CaiDatEmail_KhoiId",
                table: "CaiDatEmail");

            migrationBuilder.DropColumn(
                name: "HeDaoTaoId",
                table: "CaiDatEmail");

            migrationBuilder.DropColumn(
                name: "KhoiId",
                table: "CaiDatEmail");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CaiDatEmail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
