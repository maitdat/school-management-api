using NS.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class SuKienSapToi:BaseEntitySoftDeletable
    {
        public string TenSuKien { get; set; }
        public string TenSuKienTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public DateTime ThoiGian { get; set; }
        public string DiaDiem { get; set; }
    }
}
