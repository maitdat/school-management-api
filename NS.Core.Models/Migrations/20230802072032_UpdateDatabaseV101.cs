using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HocPhi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoHinhLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeDaoTaoId = table.Column<long>(type: "bigint", nullable: true),
                    MoHinhLopTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienHocPhi = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HocPhi_HeDaoTao_HeDaoTaoId",
                        column: x => x.HeDaoTaoId,
                        principalTable: "HeDaoTao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoaiSuKien",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiSuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSuKienTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSuKien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianBieu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianBatDau = table.Column<TimeSpan>(type: "time", nullable: false),
                    ThoiGianKetThuc = table.Column<TimeSpan>(type: "time", nullable: false),
                    TenTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTietTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaHoc = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiGianBieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LichSuKien",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenSuKien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenSuKienTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSuKienId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuKien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuKien_LoaiSuKien_LoaiSuKienId",
                        column: x => x.LoaiSuKienId,
                        principalTable: "LoaiSuKien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocPhi_HeDaoTaoId",
                table: "HocPhi",
                column: "HeDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuKien_LoaiSuKienId",
                table: "LichSuKien",
                column: "LoaiSuKienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DropTable(
                name: "HocPhi");

            migrationBuilder.DropTable(
                name: "LichSuKien");

            migrationBuilder.DropTable(
                name: "ThoiGianBieu");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "LoaiSuKien");
        }
    }
}
