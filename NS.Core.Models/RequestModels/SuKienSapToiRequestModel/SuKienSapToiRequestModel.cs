using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.SuKienSapToiRequestModel
{
    public class SuKienSapToiRequestModel:BaseEntity
    {
        [Required(ErrorMessage = "Vui lòng nhập tên sự kiện")]
        public string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }

        [Required(ErrorMessage = "Vui lòng thời gian cho sự kiện")]
        public DateTime ThoiGian { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa điểm")]
        public string DiaDiem { get; set; }
    }
}
