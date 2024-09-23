using NS.Core.Commons;

namespace NS.Core.Models.Entities
{
    public class CaiDatTongThe : BaseEntity
    {
        public long TrangId { get; set; }
        public virtual Trang Trang { get; set; }

        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; } = string.Empty;
        public string Mota { get; set; }
        public string MotaTiengAnh { get; set; }
        public string Link { get; set; }
        public string LinkAnh { get; set; }
        public long? FileId { get; set; }
        public int? ThuTu { get; set; }
        public virtual ICollection<CaiDatChiTiet> CaiDatChiTiet { get; set; }
    }
}
