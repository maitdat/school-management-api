using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class HoSoThi : Commons.BaseEntity
    {
        public long HoSoTuyenSinhId { get; set; }
        public virtual HoSoTuyenSinh HoSoTuyenSinh { get; set; }
        public long LopDuThiId { get; set; }
        public virtual LopDuThi LopDuThi { get; set; }
        public string SoBaoDanh { get; set; }
        public TrangThaiDuThi TrangThaiDuThi { get; set; }
        public TrangThaiKetQua TrangThaiKetQua { get; set; }
    }
}
