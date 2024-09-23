using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class YeuCauLienHeRequestModel
    {
        public required string HoTen { get; set; }
        public required string Email { get; set; }
        public required string SoDienThoai { get; set; }
        public required long BoPhanLienHeId { get; set; }
        public required string NoiDungLienHe { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
