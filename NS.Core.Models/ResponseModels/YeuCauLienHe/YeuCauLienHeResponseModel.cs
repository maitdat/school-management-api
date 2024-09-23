using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class YeuCauLienHeResponseModel
    {
        public long Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public long BoPhanLienHeId { get; set; }
        public string TenBoPhanLienHe { get; set; }
        public string NoiDungLienHe { get; set; }
        public bool DaPhanHoi { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
