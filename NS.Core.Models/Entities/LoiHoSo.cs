using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class LoiHoSo : Commons.BaseEntity
    {
        public long HoSoTuyenSinhId { get; set; }
        public virtual HoSoTuyenSinh HoSoTuyenSinh { get; set; }
        public long LoaiLoiHoSoId { get; set; }
        public virtual LoaiLoiHoSo LoaiLoiHoSo { get; set; }
        public required string Mota { get; set; }
        public TrangThaiSuaLoi TrangThai { get; set; }
    }
}
