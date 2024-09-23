using NS.Core.Commons;

namespace NS.Core.Models.Entities.LandingPage
{
    public class LoaiSuKienModel : BaseEntitySoftDeletable
    {
        public required string LoaiSuKien { get; set; }
        public string LoaiSuKienTiengAnh { get; set; } = String.Empty;
        public required string Color { get; set; }
    }
}