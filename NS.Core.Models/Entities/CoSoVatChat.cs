using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.Entities
{
    public class CoSoVatChat : BaseEntitySoftDeletable
    {
        public required string TenDiaDiem { get; set; }
        public string TenDiaDiemTiengAnh { get; set; }
        public required bool HienThi { get; set; }
        public List<ChiTietCoSoVatChat> ChiTietCoSoVatChat { get; set; }
    }
}
