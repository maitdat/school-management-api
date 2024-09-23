using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IsAcceptReceiveNotify",
            //    table: "TaiKhoan");

            //migrationBuilder.DropColumn(
            //    name: "IsActive",
            //    table: "TaiKhoan");

            migrationBuilder.CreateTable(
                name: "CoSoVatChat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDiaDiemTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThi = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoSoVatChat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GocTruyenThong",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoTrang = table.Column<int>(type: "int", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GocTruyenThong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenPhongBanTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThucDon",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTuanTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuHai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuBa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuNam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuSau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnSang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuHaiTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuBaTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTuTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuNamTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuSauTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnSangTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauThuHai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauThuBa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauThuTu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauThuNam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauThuSau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauAnSang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DenNgay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThucDon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoSoVatChatId = table.Column<long>(type: "bigint", nullable: false),
                    ContentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    HienThi = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_CoSoVatChat_CoSoVatChatId",
                        column: x => x.CoSoVatChatId,
                        principalTable: "CoSoVatChat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongTinLienLac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HocVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuaTrinhLamViec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChamNgon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HienThi = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanVien_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_CoSoVatChatId",
                table: "Media",
                column: "CoSoVatChatId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_PhongBanId",
                table: "NhanVien",
                column: "PhongBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GocTruyenThong");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThucDon");

            migrationBuilder.DropTable(
                name: "CoSoVatChat");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptReceiveNotify",
                table: "TaiKhoan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TaiKhoan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
