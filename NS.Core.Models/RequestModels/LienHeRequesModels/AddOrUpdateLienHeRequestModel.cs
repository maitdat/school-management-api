using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class AddOrUpdateLienHeRequestModel
    {
        public long BoPhanLienHeId { get; set; }
        public string NguoiLienHe { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
    }
}
