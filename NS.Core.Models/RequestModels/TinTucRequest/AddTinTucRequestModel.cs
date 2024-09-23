using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.TinTucRequest
{
    public class AddTinTucRequestModel
    {
        [FromForm] 
        public long? ChuyenMucId { get; set; }
        [FromForm]
        public string TieuDe { get; set; }
        [FromForm]
        public string NoiDungTomTat { get; set; }
        [FromForm]
        public string NoiDungChiTiet { get; set; }
        [FromForm]
        public DateTime NgayDang { get; set; }
        [FromForm]
        public IFormFile? AnhDaiDien { get; set; }
        [FromForm]
        public bool LaTinNoiBat { get; set; } = false;
        [FromForm]
        public Enums.LoaiBaiViet LoaiBaiViet { get; set; }
    }
}
