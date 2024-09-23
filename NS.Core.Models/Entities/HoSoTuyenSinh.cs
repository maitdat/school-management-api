using System.ComponentModel.DataAnnotations.Schema;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class HoSoTuyenSinh : Commons.BaseEntitySoftDeletable
    {
        public long KyTuyenSinhId { get; set; }
        public virtual KyTuyenSinh KyTuyenSinh { get; set; }
        public long KhoiTuyenSinhId { get; set; }
        public virtual Khoi KhoiTuyenSinh { get; set; }
        public long HeDaoTaoId { get; set; }
        public virtual HeDaoTao HeDaoTao { get; set; }
        public long TaiKhoanId { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public string? MaSoHoSo { get; set; }
        public string HoTen { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string AnhHoSo { get; set; }
        public string AnhGiayKhaiSinh { get; set; }
        public string? MaMoet { get; set; }
        public string HoKhauThuongTru { get; set; }
        public string DiaChiHienTai { get; set; }
        public string TruongDangTheoHoc { get; set; }
        public string NguoiKhaiHoSo { get; set; }
        public string AnhChiEm { get; set; }
        public string ChungChiTiengAnh { get; set; }
        public string? ThanhTichKhac { get; set; }
        public string? HoanCanhDacBiet { get; set; }
        public string? DeNghiCuaPhuHuynh { get; set; }
        public KenhGioiThieu KenhGioiThieu { get; set; }
        public bool? ThamGiaClub { get; set; }
        public TrangThaiHoSoTuyenSinh TrangThai { get; set; }
        public TrangThaiDanhSachDuThi TrangThaiDuThi { get; set; }
        public long? ThoiGianThiId { get; set; }
        public virtual ThoiGianThi ThoiGianThi { get; set; }
        public long? LopDuThiId { get; set; }
        public virtual LopDuThi LopDuThi { get; set; }
        public DateTime? NgayGiaoLuuStart { get; set; }
        public DateTime? NgayGiaoLuuEnd { get; set; }

        public DateTime? NgayGiaoLuu { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string? SucKhoe { get; set; }
        public DateTime NgayGiaoLuuBatDau { get; set; }
        public DateTime NgayGiaoLuuKetThuc { get; set; }
        public string? CaTinh { get; set; }
        public string? NangKhieu { get; set; }
        public string? SoThich { get; set; }
        public virtual ICollection<NguoiLienQuan> NguoiLienQuan { get; set; }
        public virtual ThanhTichHocTap ThanhTichHocTap { get; set; }
        public long? FileAnhHoSoId { get; set; }
        [ForeignKey("FileAnhHoSoId")]
        public virtual FileUpload FileAnhHoSo { get; set; }
        public long? FileAnhKhaiSinhId { get; set; }
        [ForeignKey("FileAnhKhaiSinhId")]
        public virtual FileUpload FileAnhGiayKhaiSinh { get; set; }

    }
}