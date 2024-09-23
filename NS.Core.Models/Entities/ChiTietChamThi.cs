using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class ChiTietChamThi : BaseEntity
    {
        public long HoSoThiId { get; set; }
        public virtual HoSoThi HoSoThi { get; set; }
        public long MonThiTuyenSinhId { get; set; }
        public virtual MonThiTuyenSinh MonThiTuyenSinh { get; set; }
        public long TieuChiMonThiId { get; set; }
        public virtual TieuChiMonThi TieuChiMonThi { get; set; }
        public int Diem { get; set; }
        public string GhiChu{ get; set; }
    }
}
