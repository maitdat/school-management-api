using NS.Core.Commons;

namespace NS.Core.Models.Entities.LandingPage
{
    public class LichSuKien : BaseEntitySoftDeletable
    {
        public required DateTime NgayBatDau { get; set; }
        public required DateTime NgayKetThuc { get; set; }
        public required string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; } = string.Empty;
        public long LoaiSuKienId { get; set; }
        public virtual LoaiSuKienModel LoaiSuKien { get; set; }

    }
}
