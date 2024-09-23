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
    public class DanhSachDuThiResponseModel : BaseEntity
    {
        public string SBD { get; set; }
        public string Nhom { get; set; }
        public ThoiGianThi ThoiGianThi { get; set; }
        public DateTime NgayGiaoLuu { get; set; }
        public DateTime GioGiaoLuu { get; set; }
        public DateTime GioDon { get; set; }
        public TrangThaiDanhSachDuThi TrangThaiDuThi { get; set; }
    }
}
