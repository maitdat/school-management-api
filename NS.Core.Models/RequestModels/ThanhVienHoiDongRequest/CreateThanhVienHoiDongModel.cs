using NS.Core.Commons;
using NS.Core.Models.Entities;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class CreateThanhVienHoiDongModel
    {
        public long HoiDongKhaoThiId { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public DateTime ThoiGianMo { get; set; }
        public DateTime ThoiGianDong { get; set; }
        public QuyenKhaoThi QuyenKhaoThi { get; set; }
        public ThanhVienHoiDong Mapping()
        {
            return new ThanhVienHoiDong
            {
                HoiDongKhaoThiId = this.HoiDongKhaoThiId,
                QuyenKhaoThi = this.QuyenKhaoThi,
                ThoiGianMo = this.ThoiGianMo,
                ThoiGianDong = this.ThoiGianDong,
                TaiKhoan = this.TaiKhoan,
                MatKhau = this.MatKhau.HashPassword()
            };
        }
    }
}
