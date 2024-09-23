using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class PhongBan : BaseEntitySoftDeletable
    {
        public required string TenPhongBan { get; set; }
        public string TenPhongBanTiengAnh { get; set; } = string.Empty;
        public LoaiPhongBan LoaiPhongBan { get; set; } = LoaiPhongBan.PhongBanKhac;

        public bool isDisplay { get; set; } = true;
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
