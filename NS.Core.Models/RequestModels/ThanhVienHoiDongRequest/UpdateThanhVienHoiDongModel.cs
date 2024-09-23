using NS.Core.Commons;
using NS.Core.Models.Entities;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class UpdateThanhVienHoiDongModel : BaseEntity
    {
        public long HoiDongKhaoThiId { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; } = string.Empty;
        public DateTime ThoiGianMo { get; set; }
        public DateTime ThoiGianDong { get; set; }
        public QuyenKhaoThi QuyenKhaoThi { get; set; }

        public void Update(ref ThanhVienHoiDong model)
        {
            model.HoiDongKhaoThiId = HoiDongKhaoThiId;
            model.QuyenKhaoThi = QuyenKhaoThi;
            model.ThoiGianMo = ThoiGianMo;
            model.ThoiGianDong = ThoiGianDong;
            model.TaiKhoan = TaiKhoan;
            model.MatKhau = string.IsNullOrEmpty(MatKhau.Trim()) ? MatKhau.HashPassword() : model.MatKhau;
        }
    }
}
