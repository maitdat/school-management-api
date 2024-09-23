using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV105 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiNgayThi_HoSoTuyenSinh_HoSoTuyenSinhId",
                table: "DoiNgayThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocPhi_HeDaoTao_HeDaoTaoId",
                table: "HocPhi");

            migrationBuilder.DropColumn(
                name: "LyDo",
                table: "DoiNgayThi");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "DoiNgayThi");

            migrationBuilder.RenameColumn(
                name: "HoSoTuyenSinhId",
                table: "DoiNgayThi",
                newName: "HoSoThiId");

            migrationBuilder.RenameIndex(
                name: "IX_DoiNgayThi_HoSoTuyenSinhId",
                table: "DoiNgayThi",
                newName: "IX_DoiNgayThi_HoSoThiId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GioDuThi",
                table: "ThoiGianThi",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GioDonCon",
                table: "ThoiGianThi",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<long>(
                name: "HeDaoTaoId",
                table: "HocPhi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NamHocPhiId",
                table: "HocPhi",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "NamHocPhi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamHocId = table.Column<long>(type: "bigint", nullable: false),
                    TuNam = table.Column<long>(type: "bigint", nullable: false),
                    DenNam = table.Column<long>(type: "bigint", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamHocPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NamHocPhi_NamHoc_NamHocId",
                        column: x => x.NamHocId,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocPhi_NamHocPhiId",
                table: "HocPhi",
                column: "NamHocPhiId");

            migrationBuilder.CreateIndex(
                name: "IX_NamHocPhi_NamHocId",
                table: "NamHocPhi",
                column: "NamHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoiNgayThi_HoSoThi_HoSoThiId",
                table: "DoiNgayThi",
                column: "HoSoThiId",
                principalTable: "HoSoThi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HocPhi_HeDaoTao_HeDaoTaoId",
                table: "HocPhi",
                column: "HeDaoTaoId",
                principalTable: "HeDaoTao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HocPhi_NamHocPhi_NamHocPhiId",
                table: "HocPhi",
                column: "NamHocPhiId",
                principalTable: "NamHocPhi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoiNgayThi_HoSoThi_HoSoThiId",
                table: "DoiNgayThi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocPhi_HeDaoTao_HeDaoTaoId",
                table: "HocPhi");

            migrationBuilder.DropForeignKey(
                name: "FK_HocPhi_NamHocPhi_NamHocPhiId",
                table: "HocPhi");

            migrationBuilder.DropTable(
                name: "NamHocPhi");

            migrationBuilder.DropIndex(
                name: "IX_HocPhi_NamHocPhiId",
                table: "HocPhi");

            migrationBuilder.DropColumn(
                name: "NamHocPhiId",
                table: "HocPhi");

            migrationBuilder.RenameColumn(
                name: "HoSoThiId",
                table: "DoiNgayThi",
                newName: "HoSoTuyenSinhId");

            migrationBuilder.RenameIndex(
                name: "IX_DoiNgayThi_HoSoThiId",
                table: "DoiNgayThi",
                newName: "IX_DoiNgayThi_HoSoTuyenSinhId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioDuThi",
                table: "ThoiGianThi",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioDonCon",
                table: "ThoiGianThi",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "HeDaoTaoId",
                table: "HocPhi",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "LyDo",
                table: "DoiNgayThi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "DoiNgayThi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DoiNgayThi_HoSoTuyenSinh_HoSoTuyenSinhId",
                table: "DoiNgayThi",
                column: "HoSoTuyenSinhId",
                principalTable: "HoSoTuyenSinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HocPhi_HeDaoTao_HeDaoTaoId",
                table: "HocPhi",
                column: "HeDaoTaoId",
                principalTable: "HeDaoTao",
                principalColumn: "Id");
        }
    }
}
