using Microsoft.IdentityModel.Tokens;
using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateTaiKhoanModel : BaseEntity
    {
        public required string HoTen { get; set; }
        public required string Email { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string AnhDaiDien { get; set; }
        public bool TrangThai { get; set; }
        public Enums.DanhSachPhanQuyen[] DanhSachQuyen { get; set; }

        public void CreateOrUpdate(ref TaiKhoan taiKhoan)
        {
            taiKhoan.AnhDaiDien = AnhDaiDien;
            taiKhoan.SoDienThoai = SoDienThoai;
            taiKhoan.Email = Email.Trim();
            taiKhoan.HoTen = HoTen;
            taiKhoan.Id = Id;
            taiKhoan.NgayCapNhat = DateTime.Now;
            taiKhoan.IsActive = TrangThai;
            taiKhoan.DanhSachQuyen = DanhSachQuyen.Select(e=> new PhanQuyen(){MaQuyen = e,TaiKhoanId = Id}).ToList();
            if (!MatKhau.IsNullOrEmpty()) taiKhoan.MatKhau = MatKhau.HashPassword();
        }
    }
}