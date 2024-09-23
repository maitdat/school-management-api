
using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel
{
    public class CreateOrUpDateLoaiSuKienRequestModel:BaseEntity
    {
        public required string LoaiSuKien { get; set; }
        public string LoaiSuKienTiengAnh { get; set; }=String.Empty;
        public required string Mau { get; set; }

        public  LoaiSuKienModel Mapping()
        {
            return new LoaiSuKienModel()
            {
                Id = this.Id,
                LoaiSuKien = this.LoaiSuKien,
                LoaiSuKienTiengAnh = this.LoaiSuKienTiengAnh,
                Color = this.Mau
            };
        }
    }
}