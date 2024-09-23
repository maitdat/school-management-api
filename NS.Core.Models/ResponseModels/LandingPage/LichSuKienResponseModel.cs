using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class LichSuKienResponseModel : BaseEntity
    {
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LoaiSuKien { get; set; }
        public string LoaiSuKienTiengAnh { get; set; }
        public string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; }
        public string Color { get; set; }

        public static LichSuKienResponseModel Mapping(LichSuKien lichSuKien)
        {
            return new LichSuKienResponseModel
            {
                Id = lichSuKien.Id,
                LoaiSuKien = lichSuKien.LoaiSuKien.LoaiSuKien,
                LoaiSuKienTiengAnh = lichSuKien.LoaiSuKien.LoaiSuKienTiengAnh,
                TenSuKien = lichSuKien.TenSuKien,
                TenSuKienTiengAnh = lichSuKien.TenSuKienTiengAnh,
                NgayBatDau = lichSuKien.NgayBatDau,
                NgayKetThuc = lichSuKien.NgayKetThuc,
                Color = lichSuKien.LoaiSuKien.Color,
            };
        }
    }
}
