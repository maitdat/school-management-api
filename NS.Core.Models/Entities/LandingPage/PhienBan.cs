using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class PhienBan : BaseEntitySoftDeletable
    {
        public long TrangId { get; set; }
        public virtual Trang Trang { get; set; }
        public TrangThaiCaiDat TrangThai { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public virtual ICollection<CaiDatTongThe> CaiDat { get; set; }
    }
}
