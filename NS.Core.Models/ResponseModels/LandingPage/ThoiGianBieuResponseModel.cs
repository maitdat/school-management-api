using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class ThoiGianBieuResponseModel:BaseEntity
    {
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianKetThuc { get; set; }
        public string TenTiet { get; set; }
        public string TenTietTiengAnh { get; set; }
        public Enums.CaHoc CaHoc { get; set; }
        public Double ThoiLuong { get; set; }
        public static ThoiGianBieuResponseModel Mapping(ThoiGianBieu model)
        {
            return new ThoiGianBieuResponseModel
            {
                Id = model.Id,
                CaHoc = model.CaHoc,
                TenTiet = model.TenTiet,
                TenTietTiengAnh = model.TenTietTiengAnh,
                ThoiGianBatDau = model.ThoiGianBatDau.ToShortTimeString(),
                ThoiGianKetThuc = model.ThoiGianKetThuc.ToShortTimeString(),
                ThoiLuong = model.ThoiLuong,
            };
        }
    }
}
