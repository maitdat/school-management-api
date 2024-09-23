using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class LoaiLePhiRequestModel
    {
        public string TenLePhi { get; set; }
        public long KyTuyenSinhId { get; set; }
        public string TenLePhiEnglish { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; } = string.Empty;
    }
}
