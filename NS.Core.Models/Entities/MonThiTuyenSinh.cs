using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class MonThiTuyenSinh : Commons.BaseEntitySoftDeletable
    {
        public long KyTuyenSinhId { get; set; }
        public virtual KyTuyenSinh KyTuyenSinh { get; set; }
        public long LopDuThiId { get; set; }
        public virtual LopDuThi LopDuThi { get; set; }
        public long MonThiId { get; set; }
        public virtual MonThi MonThi { get; set; }
        public long HeDaoTaoId { get; set; }
        public virtual HeDaoTao HeDaoTao { get; set; }
        public virtual ICollection<TieuChiMonThi> TieuChiMonThi { get; set; }
    }
}
