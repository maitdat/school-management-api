using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class BinhLuan : BaseEntitySoftDeletable
    {
        public long TinTucId { get; set; }
        public virtual TinTuc TinTuc { get; set; }
        public string NoiDung { get; set; }
        public TrangThaiBinhLuan TrangThai { get; set; } = TrangThaiBinhLuan.DangChoDuyet;
        public long TaiKhoanId { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public DateTime ThoiGianBinhLuan { get; set; }
        public bool IsActive { get; set; }
    }
}
