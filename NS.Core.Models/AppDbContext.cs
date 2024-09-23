using Microsoft.EntityFrameworkCore;
using NS.Core.Models.Entities;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<CaiDatEmail> CaiDatEmail { get; set; }
        public DbSet<ChuyenMuc> ChuyenMuc { get; set; }
        public DbSet<DoiNgayThi> DoiNgayThi { get; set; }
        public DbSet<GiaoVienTrongThi> GiaoVienTrongThi { get; set; }
        public DbSet<HeDaoTao> HeDaoTao { get; set; }
        public DbSet<HoiDongKhaoThi> HoiDongKhaoThi { get; set; }
        public DbSet<HoSoThi> HoSoThi { get; set; }
        public DbSet<HoSoTuyenSinh> HoSoTuyenSinh { get; set; }
        public DbSet<KetQuaThi> KetQuaThi { get; set; }
        public DbSet<Khoi> Khoi { get; set; }
        public DbSet<KyTuyenSinh> KyTuyenSinh { get; set; }
        public DbSet<LienHe> LienHe { get; set; }
        public DbSet<LoaiLePhi> LoaiLePhi { get; set; }
        public DbSet<LoaiLoiHoSo> LoaiLoiHoSo { get; set; }
        public DbSet<LoiHoSo> LoiHoSo { get; set; }
        public DbSet<LopDuThi> LopDuThi { get; set; }
        public DbSet<MenuConfig> MenuConfig { get; set; }
        public DbSet<MenuChuyenMuc> MenuChuyenMuc { get; set; }
        public DbSet<MonThi> MonThi { get; set; }
        public DbSet<MonThiTuyenSinh> MonThiTuyenSinh { get; set; }
        public DbSet<NamHoc> NamHoc { get; set; }
        public DbSet<NguoiLienQuan> NguoiLienQuan { get; set; }
        public DbSet<PhongVan> PhongVan { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<ThanhTichHocTap> ThanhTichHocTap { get; set; }
        public DbSet<ThanhVienHoiDong> ThanhVienHoiDong { get; set; }
        public DbSet<ThoiGianThi> ThoiGianThi { get; set; }
        public DbSet<TieuChiDanhGia> TieuChiDanhGia { get; set; }
        public DbSet<TieuChiMonThi> TieuChiMonThi { get; set; }
        public DbSet<UngVien> UngVien { get; set; }
        public DbSet<VanDe> VanDe { get; set; }
        public DbSet<VanDeLienHe> VanDeLienHe { get; set; }
        public DbSet<XacNhanPhi> XacNhanPhi { get; set; }
        public DbSet<TinTuc> TinTuc { get; set; }
        public DbSet<QuyDoiDiem> QuyDoiDiem { get; set; }
        public DbSet<BoPhanLienHe> BoPhanLienHe { get; set; }
        public DbSet<ChungChiLienQuan> ChungChiLienQuan { get; set; }
        public DbSet<HoSoTuyenDung> HoSoTuyenDung { get; set; }
        public DbSet<TinTuyenDung> TinTuyenDung { get; set; }
        public DbSet<ViTriTuyenDung> ViTriTuyenDung { get; set; }
        public DbSet<TuyenDungViTri> TuyenDungVitri { get; set; }
        public DbSet<ViTriBoSung> ViTriBoSung { get; set; }
        public DbSet<BinhLuan> BinhLuan { get; set; }
        public DbSet<ChiTietChamThi> ChiTietChamThi { get; set; }
        public DbSet<CaiDatChiTiet> CaiDatChiTiet { get; set; }
        public DbSet<CaiDatTongThe> CaiDatTongThe { get; set; }
        public DbSet<Trang> Trang { get; set; }
        public DbSet<YeuCauLienHe> YeuCauLienHe { get; set; }
        public DbSet<PhienBan> PhienBan { get; set; }
        public DbSet<ThoiGianBieu> ThoiGianBieu { get; set; }
        public DbSet<LichSuKien> LichSuKien { get; set; }
        public DbSet<LoaiSuKienModel> LoaiSuKien { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<FileUpload> FileUpload { get; set; }
        public DbSet<HocPhi> HocPhi { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<ThucDon> ThucDon { get; set; }
        public DbSet<GocTruyenThong> GocTruyenThong { get; set; }
        public DbSet<CoSoVatChat> CoSoVatChat { get; set; }
        public DbSet<ChiTietCoSoVatChat> ChiTietCoSoVatChat { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<NamHocPhi> NamHocPhi { get; set; }
        public DbSet<CauLacBo> CauLacBo { get; set; }
        public DbSet<ThongTinTruong> ThongTinTruong { get; set; }
        public DbSet<AnhCauLacBo> AnhCauLacBo { get; set; }
        public DbSet<CatDatHeThong> CatDatHeThong { get; set; }
        public DbSet<PhanQuyen> PhanQuyen { get; set; }
        public DbSet<SuKienSapToi> SuKienSapToi { get; set; }
        public DbSet<ThanhTichNoiBat> ThanhTichNoiBat{ get; set; }
        public DbSet<XacThucTaiKhoan> XacThucTaiKhoan { get; set; }
    }
}
