using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class ThoiGianThi : Commons.BaseEntitySoftDeletable
    {
        public long KyTuyenSinhId { get; set; }
        public virtual KyTuyenSinh KyTuyenSinh { get; set; }
        public int DotThi { get; set; }
        public DateTime NgayThi { get; set; }
        public CaThi CaThi { get; set; }
        public DateTime GioDuThi { get; set; }
        public DateTime GioDonCon { get; set; }
        public string GhiChu { get; set; }
    }
}
