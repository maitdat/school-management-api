using NS.Core.Models.Entities.LandingPage;
using NS.Core.Commons;

namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel
{
    public class CreateOrUpdateLichSuKienRequestModel:BaseEntity
    {
        public required DateTime NgayBatDau { get; set; }
        public required DateTime NgayKetThuc { get; set; }
        public required string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; } = string.Empty;
        public required long LoaiSuKien { get; set; }

        public  LichSuKien Mapping()
        {
            return new LichSuKien
            {
                Id = this.Id,
                NgayBatDau = this.NgayBatDau,
                NgayKetThuc = this.NgayKetThuc,
                TenSuKien = this.TenSuKien,
                TenSuKienTiengAnh = this.TenSuKienTiengAnh,
                LoaiSuKienId = this.LoaiSuKien
            };
        }
    }
}