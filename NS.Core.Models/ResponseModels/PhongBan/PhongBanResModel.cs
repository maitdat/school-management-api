using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class PhongBanResModel
    {
        public long Id { get; set; }
        public string TenPhongBan { get; set; }
        public string TenPhongBanTiengAnh { get; set; }
        public string Email { get; set; }
        public LoaiPhongBan LoaiPhongBan { get; set; } 
        public bool isDisplay { get; set; }
    }
}
