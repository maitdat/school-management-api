using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoPhanLienHe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoPhanChaId = table.Column<long>(type: "bigint", nullable: true),
                    TenBoPhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenBoPhanEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoPhanLienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoPhanLienHe_BoPhanLienHe_BoPhanChaId",
                        column: x => x.BoPhanChaId,
                        principalTable: "BoPhanLienHe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CaiDatEmail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaiDatEmail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenMuc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChuyenMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenChuyenMucEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenMuc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeDaoTao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHeDaoTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenHeDaoTaoEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeDaoTao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Khoi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKhoiEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiLePhi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLePhi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLePhiEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiLePhi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiLoiHoSo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiLoiHoSo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NamHoc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNamHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TieuChiDanhGia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTieuChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChiDanhGia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinTuyenDung",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuyenDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trang",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UngVien",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenUngVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChiThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriUngTuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UngVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VanDe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVanDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanDe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViTriTuyenDung",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenViTriTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriTuyenDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LienHe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoPhanLienHeId = table.Column<long>(type: "bigint", nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LienHe_BoPhanLienHe_BoPhanLienHeId",
                        column: x => x.BoPhanLienHeId,
                        principalTable: "BoPhanLienHe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "YeuCauLienHe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoPhanLienHeId = table.Column<long>(type: "bigint", nullable: false),
                    NoiDungLienHe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaPhanHoi = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuCauLienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YeuCauLienHe_BoPhanLienHe_BoPhanLienHeId",
                        column: x => x.BoPhanLienHeId,
                        principalTable: "BoPhanLienHe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungTomTat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungChiTiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungTomTatEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDungChiTietEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuyenMucId = table.Column<long>(type: "bigint", nullable: true),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    LaTinNoiBat = table.Column<bool>(type: "bit", nullable: false),
                    LaTinTuc = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinTuc_ChuyenMuc_ChuyenMucId",
                        column: x => x.ChuyenMucId,
                        principalTable: "ChuyenMuc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KyTuyenSinh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKyTuyenSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NamHocId = table.Column<long>(type: "bigint", nullable: false),
                    KhoiId = table.Column<long>(type: "bigint", nullable: false),
                    ChiTieuTuyenSinh = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KyTuyenSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KyTuyenSinh_Khoi_KhoiId",
                        column: x => x.KhoiId,
                        principalTable: "Khoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KyTuyenSinh_NamHoc_NamHocId",
                        column: x => x.NamHocId,
                        principalTable: "NamHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PhienBan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrangId = table.Column<long>(type: "bigint", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhienBan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhienBan_Trang_TrangId",
                        column: x => x.TrangId,
                        principalTable: "Trang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PhongVan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UngVienId = table.Column<long>(type: "bigint", nullable: false),
                    NgayPhongVan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiDungPhongVan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetQuaPhongVan = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongVan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongVan_UngVien_UngVienId",
                        column: x => x.UngVienId,
                        principalTable: "UngVien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HoSoTuyenDung",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanId = table.Column<long>(type: "bigint", nullable: false),
                    ViTriTuyenDungId = table.Column<long>(type: "bigint", nullable: false),
                    AnhHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileCV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoTuyenDung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenDung_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenDung_ViTriTuyenDung_ViTriTuyenDungId",
                        column: x => x.ViTriTuyenDungId,
                        principalTable: "ViTriTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TuyenDungVitri",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinTuyenDungId = table.Column<long>(type: "bigint", nullable: false),
                    ViTriTuyenDungId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenDungVitri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TuyenDungVitri_TinTuyenDung_TinTuyenDungId",
                        column: x => x.TinTuyenDungId,
                        principalTable: "TinTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TuyenDungVitri_ViTriTuyenDung_ViTriTuyenDungId",
                        column: x => x.ViTriTuyenDungId,
                        principalTable: "ViTriTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "VanDeLienHe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanDeId = table.Column<long>(type: "bigint", nullable: false),
                    LienHeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanDeLienHe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanDeLienHe_LienHe_LienHeId",
                        column: x => x.LienHeId,
                        principalTable: "LienHe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VanDeLienHe_VanDe_VanDeId",
                        column: x => x.VanDeId,
                        principalTable: "VanDe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TinTucId = table.Column<long>(type: "bigint", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    TaiKhoanId = table.Column<long>(type: "bigint", nullable: false),
                    ThoiGianBinhLuan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinhLuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinhLuan_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BinhLuan_TinTuc_TinTucId",
                        column: x => x.TinTucId,
                        principalTable: "TinTuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MenuConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinTuctId = table.Column<long>(type: "bigint", nullable: true),
                    TinTucId = table.Column<long>(type: "bigint", nullable: true),
                    LinkBanner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuConfig_MenuConfig_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MenuConfig",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuConfig_TinTuc_TinTucId",
                        column: x => x.TinTucId,
                        principalTable: "TinTuc",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HoiDongKhaoThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    TenHoiDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoiDongKhaoThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoiDongKhaoThi_KyTuyenSinh_KyTuyenSinhId",
                        column: x => x.KyTuyenSinhId,
                        principalTable: "KyTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ThoiGianThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    DotThi = table.Column<int>(type: "int", nullable: false),
                    NgayThi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaThi = table.Column<int>(type: "int", nullable: false),
                    GioDuThi = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioDonCon = table.Column<TimeSpan>(type: "time", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThoiGianThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThoiGianThi_KyTuyenSinh_KyTuyenSinhId",
                        column: x => x.KyTuyenSinhId,
                        principalTable: "KyTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CaiDatTongThe",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhienBanId = table.Column<long>(type: "bigint", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotaTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaiDatTongThe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaiDatTongThe_PhienBan_PhienBanId",
                        column: x => x.PhienBanId,
                        principalTable: "PhienBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChungChiLienQuan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoTuyenDungId = table.Column<long>(type: "bigint", nullable: false),
                    TenChungChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileChungChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetQua = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChungChiLienQuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChungChiLienQuan_HoSoTuyenDung_HoSoTuyenDungId",
                        column: x => x.HoSoTuyenDungId,
                        principalTable: "HoSoTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ViTriBoSung",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoTuyenDungId = table.Column<long>(type: "bigint", nullable: false),
                    ViTriTuyenDungId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriBoSung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViTriBoSung_HoSoTuyenDung_HoSoTuyenDungId",
                        column: x => x.HoSoTuyenDungId,
                        principalTable: "HoSoTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ViTriBoSung_ViTriTuyenDung_ViTriTuyenDungId",
                        column: x => x.ViTriTuyenDungId,
                        principalTable: "ViTriTuyenDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MenuChuyenMuc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuConfigId = table.Column<long>(type: "bigint", nullable: false),
                    ChuyenMucId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuChuyenMuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuChuyenMuc_ChuyenMuc_ChuyenMucId",
                        column: x => x.ChuyenMucId,
                        principalTable: "ChuyenMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MenuChuyenMuc_MenuConfig_MenuConfigId",
                        column: x => x.MenuConfigId,
                        principalTable: "MenuConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVienHoiDong",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoiDongKhaoThiId = table.Column<long>(type: "bigint", nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianMo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianDong = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuyenKhaoThi = table.Column<int>(type: "int", nullable: false),
                    DangKichHoat = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVienHoiDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhVienHoiDong_HoiDongKhaoThi_HoiDongKhaoThiId",
                        column: x => x.HoiDongKhaoThiId,
                        principalTable: "HoiDongKhaoThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CaiDatChiTiet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaiDatTongTheId = table.Column<long>(type: "bigint", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTaTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaiDatChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaiDatChiTiet_CaiDatTongThe_CaiDatTongTheId",
                        column: x => x.CaiDatTongTheId,
                        principalTable: "CaiDatTongThe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LopDuThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiaoVienChinhId = table.Column<long>(type: "bigint", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViTriPhongThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopDuThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopDuThi_ThanhVienHoiDong_GiaoVienChinhId",
                        column: x => x.GiaoVienChinhId,
                        principalTable: "ThanhVienHoiDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GiaoVienTrongThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopDuThiId = table.Column<long>(type: "bigint", nullable: false),
                    ThanhVienHoiDongId = table.Column<long>(type: "bigint", nullable: false),
                    LaGiaoVienChinh = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVienTrongThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiaoVienTrongThi_LopDuThi_LopDuThiId",
                        column: x => x.LopDuThiId,
                        principalTable: "LopDuThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GiaoVienTrongThi_ThanhVienHoiDong_ThanhVienHoiDongId",
                        column: x => x.ThanhVienHoiDongId,
                        principalTable: "ThanhVienHoiDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HoSoTuyenSinh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    KhoiTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    HeDaoTaoId = table.Column<long>(type: "bigint", nullable: false),
                    TaiKhoanId = table.Column<long>(type: "bigint", nullable: false),
                    MaSoHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhGiayKhaiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMoet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoKhauThuongTru = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiHienTai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruongDangTheoHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiKhaiHoSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhChiEm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChungChiTiengAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThanhTichKhac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoanCanhDacBiet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeNghiCuaPhuHuynh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KenhGioiThieu = table.Column<int>(type: "int", nullable: false),
                    ThamGiaClub = table.Column<bool>(type: "bit", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    TrangThaiDuThi = table.Column<int>(type: "int", nullable: false),
                    ThoiGianThiId = table.Column<long>(type: "bigint", nullable: false),
                    LopDuThiId = table.Column<long>(type: "bigint", nullable: false),
                    NgayGiaoLuuStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaoLuuEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaoLuu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SucKhoe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGiaoLuuBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaoLuuKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NangKhieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoThich = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoTuyenSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_HeDaoTao_HeDaoTaoId",
                        column: x => x.HeDaoTaoId,
                        principalTable: "HeDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_Khoi_KhoiTuyenSinhId",
                        column: x => x.KhoiTuyenSinhId,
                        principalTable: "Khoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_KyTuyenSinh_KyTuyenSinhId",
                        column: x => x.KyTuyenSinhId,
                        principalTable: "KyTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_LopDuThi_LopDuThiId",
                        column: x => x.LopDuThiId,
                        principalTable: "LopDuThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_TaiKhoan_TaiKhoanId",
                        column: x => x.TaiKhoanId,
                        principalTable: "TaiKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoTuyenSinh_ThoiGianThi_ThoiGianThiId",
                        column: x => x.ThoiGianThiId,
                        principalTable: "ThoiGianThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MonThiTuyenSinh",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    LopDuThiId = table.Column<long>(type: "bigint", nullable: false),
                    MonThiId = table.Column<long>(type: "bigint", nullable: false),
                    HeDaoTaoId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonThiTuyenSinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonThiTuyenSinh_HeDaoTao_HeDaoTaoId",
                        column: x => x.HeDaoTaoId,
                        principalTable: "HeDaoTao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MonThiTuyenSinh_KyTuyenSinh_KyTuyenSinhId",
                        column: x => x.KyTuyenSinhId,
                        principalTable: "KyTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MonThiTuyenSinh_LopDuThi_LopDuThiId",
                        column: x => x.LopDuThiId,
                        principalTable: "LopDuThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MonThiTuyenSinh_MonThi_MonThiId",
                        column: x => x.MonThiId,
                        principalTable: "MonThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DoiNgayThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiGianThiId = table.Column<long>(type: "bigint", nullable: false),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    LyDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiNgayThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoiNgayThi_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DoiNgayThi_ThoiGianThi_ThoiGianThiId",
                        column: x => x.ThoiGianThiId,
                        principalTable: "ThoiGianThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HoSoThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    LopDuThiId = table.Column<long>(type: "bigint", nullable: false),
                    SoBaoDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiDuThi = table.Column<int>(type: "int", nullable: false),
                    TrangThaiKetQua = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoThi_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoThi_LopDuThi_LopDuThiId",
                        column: x => x.LopDuThiId,
                        principalTable: "LopDuThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LoiHoSo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    LoaiLoiHoSoId = table.Column<long>(type: "bigint", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoiHoSo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoiHoSo_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LoiHoSo_LoaiLoiHoSo_LoaiLoiHoSoId",
                        column: x => x.LoaiLoiHoSoId,
                        principalTable: "LoaiLoiHoSo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NguoiLienQuan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    LoaiQuanHe = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoaiCoQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiLienQuan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NguoiLienQuan_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ThanhTichHocTap",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoiHocTapId = table.Column<long>(type: "bigint", nullable: false),
                    KhoiId = table.Column<long>(type: "bigint", nullable: true),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    DaHoanThanhKienThuc = table.Column<bool>(type: "bit", nullable: false),
                    DaDatNangLuc = table.Column<bool>(type: "bit", nullable: false),
                    DaDatKyNang = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhTichHocTap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhTichHocTap_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ThanhTichHocTap_Khoi_KhoiId",
                        column: x => x.KhoiId,
                        principalTable: "Khoi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "XacNhanPhi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiLePhiId = table.Column<long>(type: "bigint", nullable: false),
                    HoSoTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    SoChungTu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXacNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTienNhan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XacNhanPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XacNhanPhi_HoSoTuyenSinh_HoSoTuyenSinhId",
                        column: x => x.HoSoTuyenSinhId,
                        principalTable: "HoSoTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_XacNhanPhi_LoaiLePhi_LoaiLePhiId",
                        column: x => x.LoaiLePhiId,
                        principalTable: "LoaiLePhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuyDoiDiem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonThiTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    DiemBatDau = table.Column<int>(type: "int", nullable: false),
                    DiemKetThuc = table.Column<int>(type: "int", nullable: false),
                    KetQua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDoiDiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyDoiDiem_MonThiTuyenSinh_MonThiTuyenSinhId",
                        column: x => x.MonThiTuyenSinhId,
                        principalTable: "MonThiTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TieuChiMonThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonThiTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    TieuChiDanhGiaId = table.Column<long>(type: "bigint", nullable: false),
                    HeSo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TieuChiMonThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TieuChiMonThi_MonThiTuyenSinh_MonThiTuyenSinhId",
                        column: x => x.MonThiTuyenSinhId,
                        principalTable: "MonThiTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TieuChiMonThi_TieuChiDanhGia_TieuChiDanhGiaId",
                        column: x => x.TieuChiDanhGiaId,
                        principalTable: "TieuChiDanhGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KetQuaThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonThiTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    HoSoThiId = table.Column<long>(type: "bigint", nullable: false),
                    TieuChiDanhGiaId = table.Column<long>(type: "bigint", nullable: false),
                    ThanhVienHoiDongId = table.Column<long>(type: "bigint", nullable: false),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    QuyDoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanXet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuaThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQuaThi_HoSoThi_HoSoThiId",
                        column: x => x.HoSoThiId,
                        principalTable: "HoSoThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KetQuaThi_MonThiTuyenSinh_MonThiTuyenSinhId",
                        column: x => x.MonThiTuyenSinhId,
                        principalTable: "MonThiTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KetQuaThi_ThanhVienHoiDong_ThanhVienHoiDongId",
                        column: x => x.ThanhVienHoiDongId,
                        principalTable: "ThanhVienHoiDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KetQuaThi_TieuChiDanhGia_TieuChiDanhGiaId",
                        column: x => x.TieuChiDanhGiaId,
                        principalTable: "TieuChiDanhGia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietChamThi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoSoThiId = table.Column<long>(type: "bigint", nullable: false),
                    MonThiTuyenSinhId = table.Column<long>(type: "bigint", nullable: false),
                    TieuChiMonThiId = table.Column<long>(type: "bigint", nullable: false),
                    Diem = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietChamThi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietChamThi_HoSoThi_HoSoThiId",
                        column: x => x.HoSoThiId,
                        principalTable: "HoSoThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ChiTietChamThi_MonThiTuyenSinh_MonThiTuyenSinhId",
                        column: x => x.MonThiTuyenSinhId,
                        principalTable: "MonThiTuyenSinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ChiTietChamThi_TieuChiMonThi_TieuChiMonThiId",
                        column: x => x.TieuChiMonThiId,
                        principalTable: "TieuChiMonThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_TaiKhoanId",
                table: "BinhLuan",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_TinTucId",
                table: "BinhLuan",
                column: "TinTucId");

            migrationBuilder.CreateIndex(
                name: "IX_BoPhanLienHe_BoPhanChaId",
                table: "BoPhanLienHe",
                column: "BoPhanChaId");

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatChiTiet_CaiDatTongTheId",
                table: "CaiDatChiTiet",
                column: "CaiDatTongTheId");

            migrationBuilder.CreateIndex(
                name: "IX_CaiDatTongThe_PhienBanId",
                table: "CaiDatTongThe",
                column: "PhienBanId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChamThi_HoSoThiId",
                table: "ChiTietChamThi",
                column: "HoSoThiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChamThi_MonThiTuyenSinhId",
                table: "ChiTietChamThi",
                column: "MonThiTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietChamThi_TieuChiMonThiId",
                table: "ChiTietChamThi",
                column: "TieuChiMonThiId");

            migrationBuilder.CreateIndex(
                name: "IX_ChungChiLienQuan_HoSoTuyenDungId",
                table: "ChungChiLienQuan",
                column: "HoSoTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiNgayThi_HoSoTuyenSinhId",
                table: "DoiNgayThi",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DoiNgayThi_ThoiGianThiId",
                table: "DoiNgayThi",
                column: "ThoiGianThiId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoVienTrongThi_LopDuThiId",
                table: "GiaoVienTrongThi",
                column: "LopDuThiId");

            migrationBuilder.CreateIndex(
                name: "IX_GiaoVienTrongThi_ThanhVienHoiDongId",
                table: "GiaoVienTrongThi",
                column: "ThanhVienHoiDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoiDongKhaoThi_KyTuyenSinhId",
                table: "HoiDongKhaoThi",
                column: "KyTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoThi_HoSoTuyenSinhId",
                table: "HoSoThi",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoThi_LopDuThiId",
                table: "HoSoThi",
                column: "LopDuThiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenDung_TaiKhoanId",
                table: "HoSoTuyenDung",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenDung_ViTriTuyenDungId",
                table: "HoSoTuyenDung",
                column: "ViTriTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_HeDaoTaoId",
                table: "HoSoTuyenSinh",
                column: "HeDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_KhoiTuyenSinhId",
                table: "HoSoTuyenSinh",
                column: "KhoiTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_KyTuyenSinhId",
                table: "HoSoTuyenSinh",
                column: "KyTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_LopDuThiId",
                table: "HoSoTuyenSinh",
                column: "LopDuThiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_TaiKhoanId",
                table: "HoSoTuyenSinh",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoTuyenSinh_ThoiGianThiId",
                table: "HoSoTuyenSinh",
                column: "ThoiGianThiId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaThi_HoSoThiId",
                table: "KetQuaThi",
                column: "HoSoThiId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaThi_MonThiTuyenSinhId",
                table: "KetQuaThi",
                column: "MonThiTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaThi_ThanhVienHoiDongId",
                table: "KetQuaThi",
                column: "ThanhVienHoiDongId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaThi_TieuChiDanhGiaId",
                table: "KetQuaThi",
                column: "TieuChiDanhGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_KyTuyenSinh_KhoiId",
                table: "KyTuyenSinh",
                column: "KhoiId");

            migrationBuilder.CreateIndex(
                name: "IX_KyTuyenSinh_NamHocId",
                table: "KyTuyenSinh",
                column: "NamHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LienHe_BoPhanLienHeId",
                table: "LienHe",
                column: "BoPhanLienHeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoiHoSo_HoSoTuyenSinhId",
                table: "LoiHoSo",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_LoiHoSo_LoaiLoiHoSoId",
                table: "LoiHoSo",
                column: "LoaiLoiHoSoId");

            migrationBuilder.CreateIndex(
                name: "IX_LopDuThi_GiaoVienChinhId",
                table: "LopDuThi",
                column: "GiaoVienChinhId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuChuyenMuc_ChuyenMucId",
                table: "MenuChuyenMuc",
                column: "ChuyenMucId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuChuyenMuc_MenuConfigId",
                table: "MenuChuyenMuc",
                column: "MenuConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuConfig_ParentId",
                table: "MenuConfig",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuConfig_TinTucId",
                table: "MenuConfig",
                column: "TinTucId");

            migrationBuilder.CreateIndex(
                name: "IX_MonThiTuyenSinh_HeDaoTaoId",
                table: "MonThiTuyenSinh",
                column: "HeDaoTaoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonThiTuyenSinh_KyTuyenSinhId",
                table: "MonThiTuyenSinh",
                column: "KyTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_MonThiTuyenSinh_LopDuThiId",
                table: "MonThiTuyenSinh",
                column: "LopDuThiId");

            migrationBuilder.CreateIndex(
                name: "IX_MonThiTuyenSinh_MonThiId",
                table: "MonThiTuyenSinh",
                column: "MonThiId");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiLienQuan_HoSoTuyenSinhId",
                table: "NguoiLienQuan",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_PhienBan_TrangId",
                table: "PhienBan",
                column: "TrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongVan_UngVienId",
                table: "PhongVan",
                column: "UngVienId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyDoiDiem_MonThiTuyenSinhId",
                table: "QuyDoiDiem",
                column: "MonThiTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhTichHocTap_HoSoTuyenSinhId",
                table: "ThanhTichHocTap",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhTichHocTap_KhoiId",
                table: "ThanhTichHocTap",
                column: "KhoiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienHoiDong_HoiDongKhaoThiId",
                table: "ThanhVienHoiDong",
                column: "HoiDongKhaoThiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThoiGianThi_KyTuyenSinhId",
                table: "ThoiGianThi",
                column: "KyTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiMonThi_MonThiTuyenSinhId",
                table: "TieuChiMonThi",
                column: "MonThiTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_TieuChiMonThi_TieuChiDanhGiaId",
                table: "TieuChiMonThi",
                column: "TieuChiDanhGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_ChuyenMucId",
                table: "TinTuc",
                column: "ChuyenMucId");

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDungVitri_TinTuyenDungId",
                table: "TuyenDungVitri",
                column: "TinTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_TuyenDungVitri_ViTriTuyenDungId",
                table: "TuyenDungVitri",
                column: "ViTriTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_VanDeLienHe_LienHeId",
                table: "VanDeLienHe",
                column: "LienHeId");

            migrationBuilder.CreateIndex(
                name: "IX_VanDeLienHe_VanDeId",
                table: "VanDeLienHe",
                column: "VanDeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViTriBoSung_HoSoTuyenDungId",
                table: "ViTriBoSung",
                column: "HoSoTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_ViTriBoSung_ViTriTuyenDungId",
                table: "ViTriBoSung",
                column: "ViTriTuyenDungId");

            migrationBuilder.CreateIndex(
                name: "IX_XacNhanPhi_HoSoTuyenSinhId",
                table: "XacNhanPhi",
                column: "HoSoTuyenSinhId");

            migrationBuilder.CreateIndex(
                name: "IX_XacNhanPhi_LoaiLePhiId",
                table: "XacNhanPhi",
                column: "LoaiLePhiId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuCauLienHe_BoPhanLienHeId",
                table: "YeuCauLienHe",
                column: "BoPhanLienHeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "CaiDatChiTiet");

            migrationBuilder.DropTable(
                name: "CaiDatEmail");

            migrationBuilder.DropTable(
                name: "ChiTietChamThi");

            migrationBuilder.DropTable(
                name: "ChungChiLienQuan");

            migrationBuilder.DropTable(
                name: "DoiNgayThi");

            migrationBuilder.DropTable(
                name: "GiaoVienTrongThi");

            migrationBuilder.DropTable(
                name: "KetQuaThi");

            migrationBuilder.DropTable(
                name: "LoiHoSo");

            migrationBuilder.DropTable(
                name: "MenuChuyenMuc");

            migrationBuilder.DropTable(
                name: "NguoiLienQuan");

            migrationBuilder.DropTable(
                name: "PhongVan");

            migrationBuilder.DropTable(
                name: "QuyDoiDiem");

            migrationBuilder.DropTable(
                name: "ThanhTichHocTap");

            migrationBuilder.DropTable(
                name: "TuyenDungVitri");

            migrationBuilder.DropTable(
                name: "VanDeLienHe");

            migrationBuilder.DropTable(
                name: "ViTriBoSung");

            migrationBuilder.DropTable(
                name: "XacNhanPhi");

            migrationBuilder.DropTable(
                name: "YeuCauLienHe");

            migrationBuilder.DropTable(
                name: "CaiDatTongThe");

            migrationBuilder.DropTable(
                name: "TieuChiMonThi");

            migrationBuilder.DropTable(
                name: "HoSoThi");

            migrationBuilder.DropTable(
                name: "LoaiLoiHoSo");

            migrationBuilder.DropTable(
                name: "MenuConfig");

            migrationBuilder.DropTable(
                name: "UngVien");

            migrationBuilder.DropTable(
                name: "TinTuyenDung");

            migrationBuilder.DropTable(
                name: "LienHe");

            migrationBuilder.DropTable(
                name: "VanDe");

            migrationBuilder.DropTable(
                name: "HoSoTuyenDung");

            migrationBuilder.DropTable(
                name: "LoaiLePhi");

            migrationBuilder.DropTable(
                name: "PhienBan");

            migrationBuilder.DropTable(
                name: "MonThiTuyenSinh");

            migrationBuilder.DropTable(
                name: "TieuChiDanhGia");

            migrationBuilder.DropTable(
                name: "HoSoTuyenSinh");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "BoPhanLienHe");

            migrationBuilder.DropTable(
                name: "ViTriTuyenDung");

            migrationBuilder.DropTable(
                name: "Trang");

            migrationBuilder.DropTable(
                name: "MonThi");

            migrationBuilder.DropTable(
                name: "HeDaoTao");

            migrationBuilder.DropTable(
                name: "LopDuThi");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThoiGianThi");

            migrationBuilder.DropTable(
                name: "ChuyenMuc");

            migrationBuilder.DropTable(
                name: "ThanhVienHoiDong");

            migrationBuilder.DropTable(
                name: "HoiDongKhaoThi");

            migrationBuilder.DropTable(
                name: "KyTuyenSinh");

            migrationBuilder.DropTable(
                name: "Khoi");

            migrationBuilder.DropTable(
                name: "NamHoc");
        }
    }
}
