using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class HocPhi : BaseEntitySoftDeletable
    {
        public long NamHocPhiId { get; set; }
        public virtual NamHocPhi NamHocPhi { get; set; }
        public long HeDaoTaoId { get; set; }
        public virtual HeDaoTao HeDaoTao { get; set; }
        public string Lop { get; set; }
        public int TienHocPhi { get; set; }
    }
}