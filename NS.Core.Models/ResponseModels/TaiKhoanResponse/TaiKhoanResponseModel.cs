using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels
{
    public class TaiKhoanResponseModel : BaseEntity
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TrangThai { get; set; }
        public Enums.DanhSachPhanQuyen[] DanhSachQuyen { get; set; } 

        public static TaiKhoanResponseModel Mapping(TaiKhoan taiKhoan)
        {
            return new TaiKhoanResponseModel
            {
                Id = taiKhoan.Id,
                Email = taiKhoan.Email,
                HoTen = taiKhoan.HoTen,
                SoDienThoai = taiKhoan.SoDienThoai,
                AnhDaiDien = taiKhoan.AnhDaiDien,
                NgayTao = taiKhoan.NgayTao,
                DanhSachQuyen = taiKhoan.DanhSachQuyen?.Select(e=>e.MaQuyen).ToArray(),
                TrangThai = taiKhoan.IsActive
            };
        }
    }
}
