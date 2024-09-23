using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.CMSLandingPage
{
    public class CaiDatTongTheRequestModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề.")]
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public string MotaTiengAnh { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public List<CaiDatChiTietRequestModel> CaiDatChiTiet { get; set; }
    }
}
