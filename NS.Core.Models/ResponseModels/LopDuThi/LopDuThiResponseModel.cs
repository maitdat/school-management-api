using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels
{
    public class LopDuThiResponseModel
    {
        public long Id { get; set; }
        public string GiaoVienTrongThi { get; set; }
        public string TenLop { get; set; }
        public int SoLuong { get; set; }
        public int ConTrong { get; set; }
        public DateTime NgayGiaoLuu { get; set; }
        public DateTime GioGiaoLuu { get; set; }
        public DateTime GioDon { get; set; }

        public static LopDuThiResponseModel Mapping(Entities.LopDuThi model)
        {
            var tenGiaoVienChinh = model.GiaoVienTrongThi
                    .Where(e => e.LaGiaoVienChinh)
                    .Select(e => e.ThanhVienHoiDong.TaiKhoan)
                    .FirstOrDefault()
                    ;
            return new LopDuThiResponseModel
            {
                Id = model.Id,
                TenLop = model.TenLop,
                ConTrong = model.ConTrong,
                SoLuong = model.SoLuong,
                GioGiaoLuu = model.ThoiGianThi.GioDuThi,
                GioDon = model.ThoiGianThi.GioDonCon,
                NgayGiaoLuu = model.ThoiGianThi.NgayThi,
                GiaoVienTrongThi = tenGiaoVienChinh
            };
        }
    }
}
