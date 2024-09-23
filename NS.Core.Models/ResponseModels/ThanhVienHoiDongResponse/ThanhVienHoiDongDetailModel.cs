using NS.Core.Models.Entities;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels.ThanhVienHoiDongResponse
{
    public class ThanhVienHoiDongDetailModel
    {
        public long HoiDongKhaoThiId { get; set; }
        public string HoiDongKhaoThi { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime ThoiGianMo { get; set; }
        public DateTime ThoiGianDong { get; set; }
        public QuyenKhaoThi QuyenKhaoThi { get; set; }
        public bool DangKichHoat { get; set; }

        public static ThanhVienHoiDongResponseModel Mapping(ThanhVienHoiDong model)
        {
            return new ThanhVienHoiDongResponseModel
            {
                Id = model.Id,
                TaiKhoan = model.TaiKhoan,
                HoiDongKhaoThiId = model.HoiDongKhaoThiId,
                HoiDongKhaoThi = model.HoiDongKhaoThi.TenHoiDong,
                QuyenKhaoThi = model.QuyenKhaoThi,
                ThoiGianDong = model.ThoiGianDong,
                ThoiGianMo = model.ThoiGianMo,
                DangKichHoat = model.DangKichHoat,
            };
        }
    }
}
