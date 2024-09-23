using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels.PhongBanRequestModel
{
    public class PhongBanRequestModel
    {
        public required string TenPhongBan { get; set; }
        public string TenPhongBanTiengAnh { get; set; } = string.Empty;
        public LoaiPhongBan LoaiPhongBan { get; set; }
    }
}
