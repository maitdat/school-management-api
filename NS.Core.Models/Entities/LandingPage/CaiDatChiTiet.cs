using NS.Core.Commons;

namespace NS.Core.Models.Entities
{
    public class CaiDatChiTiet : BaseEntity
    {
        public long CaiDatTongTheId { get; set; }
        public virtual CaiDatTongThe CaiDatTongThe { get; set; }
        public long? FileId { get; set; }
        public virtual FileUpload File { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string LinkAnh { get; set; }
        public int? ThuTu { get; set; }
        public bool IsActive { get; set; }
    }
}
