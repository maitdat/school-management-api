using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class NguoiLienQuanResponseModel
    {
        public long Id { get; set; }
        public long HoSoTuyenSinhId { get; set; }
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
