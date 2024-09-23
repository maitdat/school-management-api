using NS.Core.Commons;

namespace NS.Core.Models.Entities
{
    public class NamHocPhi : BaseEntitySoftDeletable
    {
        public long NamHocId { get; set; }
        public virtual NamHoc NamHoc { get; set; }
        public string NoiDung { get; set; }
        public string NoiDungTiengAnh { get; set; }
        public virtual ICollection<HocPhi> HocPhi { get; set; }
    }
}
