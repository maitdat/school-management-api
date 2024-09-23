using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.RequestModels
{
    public class RegisterData
    {
        public required string HoTen { get; set; }
        private string email { get; set; }

        public required string MatKhau { get; set; }
        public string? SoDienThoai { get; set; }
        public string? AnhDaiDien { get; set; }
        public bool IsActive { get; set; } = false;
        public required string Email
        {
            get { return email.Trim().ToLower(); }
            set { email = value.Trim().ToLower(); }
        }

        public TaiKhoan Mapping(bool isNeedConfirmEmail)
        {
            return new TaiKhoan
            {
                AnhDaiDien = AnhDaiDien,
                MatKhau = MatKhau,
                SoDienThoai = SoDienThoai,
                Email = Email,
                HoTen = HoTen,
                NgayTao = DateTime.Now,
                IsActive = !isNeedConfirmEmail,
                DanhSachQuyen = new List<PhanQuyen>()
                {
                    new PhanQuyen()
                    {
                        MaQuyen = Enums.DanhSachPhanQuyen.PhuHuynhHoacUngVien,
                    }
                 }
            };
        }
    }
}