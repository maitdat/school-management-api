using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class LoaiSuKienResponseModel:BaseEntity
    {
        public string LoaiSuKien { get; set; }
        public string LoaiSuKienTiengAnh { get; set; }
        public string Mau { get; set; }
        
        public static LoaiSuKienResponseModel Mapping(LoaiSuKienModel model)
        {
            return new LoaiSuKienResponseModel
            {
                Id = model.Id,
                LoaiSuKien = model.LoaiSuKien,
                LoaiSuKienTiengAnh = model.Color,
                Mau = model.Color,
            };
        }
    }
}
