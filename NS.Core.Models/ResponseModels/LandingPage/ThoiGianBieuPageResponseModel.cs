using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class ThoiGianBieuPageResponseModel
    {
        public List<ThoiGianBieuResponseModel> ThoiGianBieu { get; set; }
        public List<LichSuKienResponseModel> LichSuKien { get; set; }
        public List<LoaiSuKienResponseModel> LoaiSuKien { get; set; }

        public static ThoiGianBieuPageResponseModel Mapping(
            List<ThoiGianBieuResponseModel> thoiGianBieuList,
            List<LichSuKien> lichSuKienList,
            List<LoaiSuKienResponseModel> loaiSuKienList
        )
        {
            return new ThoiGianBieuPageResponseModel
            {
                ThoiGianBieu = thoiGianBieuList,
                LichSuKien = lichSuKienList.Select(e => LichSuKienResponseModel.Mapping(e)).ToList(),
                LoaiSuKien = loaiSuKienList,
            };
        }
    }
}