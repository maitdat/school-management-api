using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedTinTucRequestModel : BasePaginationRequestModel
    {
        public long? ChuyenMucId { get; set; }
        public Enums.TrangThaiTinTuc? TrangThai { get; set; }
        public string? TenChuyenMuc { get; set; }
        public string? TacGia { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? LaTinNoiBat { get; set; }
    }
}
