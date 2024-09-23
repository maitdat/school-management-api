using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class XacNhanPhi : Commons.BaseEntity
    {
        public long LoaiLePhiId { get; set; }
        public virtual LoaiLePhi LoaiLePhi { get; set; }
        public long HoSoTuyenSinhId { get; set; }
        public virtual HoSoTuyenSinh HoSoTuyenSinh { get; set; }
        public required string SoChungTu { get; set; }
        public DateTime NgayXacNhan { get; set; }
        public decimal SoTienNhan { get; set; }
        public string GhiChu { get; set; } 
    }
}
