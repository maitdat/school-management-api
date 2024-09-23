using NS.Core.Commons;

namespace NS.Core.Models.Entities
{
    public class ChungChiLienQuan : BaseEntity
    {
        public long HoSoTuyenDungId { get; set; }
        public virtual HoSoTuyenDung HoSoTuyenDung { get; set; }
        public string TenChungChi { get; set; }
        public string FileChungChi { get; set; }
        public string KetQua { get; set; }
    }
}