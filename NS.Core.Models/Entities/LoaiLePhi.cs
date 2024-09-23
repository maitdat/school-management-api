using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class LoaiLePhi : Commons.BaseEntitySoftDeletable
    {
        public required string TenLePhi { get; set; }
        public required string TenLePhiEnglish { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
        public long KyTuyenSinhId { get; set; }
        public virtual KyTuyenSinh KyTuyenSinh { get; set; }
    }
}
