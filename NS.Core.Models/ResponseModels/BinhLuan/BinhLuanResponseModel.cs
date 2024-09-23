using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class BinhLuanResponseModel
    {
        public long Id { get; set; }
        public long? TinTucId { get; set; }
        public string NoiDung { get; set; }
        public TrangThaiBinhLuan TrangThai { get; set; }
        public bool IsDeleted { get; set; }
        public string TieuDe { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string Avatar { get; set; }
        public DateTime ThoiGianBinhLuan { get; set; }
        public bool IsActive { get; set; }
    }
}
