using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class NguoiLienQuan : Commons.BaseEntitySoftDeletable
    {
        public long HoSoTuyenSinhId { get; set; }
        public virtual HoSoTuyenSinh HoSoTuyenSinh { get; set; }
        public LoaiQuanHe LoaiQuanHe { get; set; }
        public required string HoTen { get; set; }
        public required string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string CoQuan { get; set; }
        public string NgheNghiep { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoaiCoQuan { get; set; }
    }
}
