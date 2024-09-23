using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class ThanhTichHocTap : Commons.BaseEntity
    {
        public long KhoiHocTapId { get; set; }
        public virtual Khoi Khoi { get; set; }
        public long HoSoTuyenSinhId { get; set; }
        public virtual HoSoTuyenSinh HoSoTuyenSinh { get; set; }
        public NangLucPhamChat DatPhamChat { get; set; }
        public NangLucPhamChat DaDatNangLuc { get; set; }
        public NangLucPhamChat DaDatKyNang { get; set; }
    }
}
