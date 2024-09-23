using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class ThanhVienHoiDong : Commons.BaseEntitySoftDeletable
    {
        public long HoiDongKhaoThiId { get; set; }
        public virtual HoiDongKhaoThi HoiDongKhaoThi { get; set; }
        public virtual GiaoVienTrongThi GiaoVienTrongThi { get; set; }

        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public DateTime ThoiGianMo { get; set; }
        public DateTime ThoiGianDong { get; set; }
        public QuyenKhaoThi QuyenKhaoThi { get; set; }
        public bool DangKichHoat { get; set; }
    }
}