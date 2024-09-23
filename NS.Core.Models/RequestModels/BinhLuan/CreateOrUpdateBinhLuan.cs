using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateBinhLuan
    {
        public long TinTucId { get; set; }
        public string NoiDung { get; set; }
        public TrangThaiBinhLuan TrangThai { get; set; } = TrangThaiBinhLuan.DangChoDuyet;
        public long TaiKhoanId { get; set; }
        public DateTime ThoiGianBinhLuan { get; set; }
        public bool IsActive { get; set; }
    }
}
