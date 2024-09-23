using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class LoaiLePhiResponseModel
    {
        public long Id { get; set; }
        public long KyTuyenSinhId { get; set; }
        public string TenKyTuyenSinh { get; set; }
        public string TenLePhi { get; set; }
        public string TenLePhiEnglish { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
    }
}
