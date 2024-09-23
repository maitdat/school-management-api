using NS.Core.Commons;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class PhanQuyen : BaseEntitySoftDeletable
    {
        public long TaiKhoanId { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public DanhSachPhanQuyen MaQuyen { get; set; }
    }
}
