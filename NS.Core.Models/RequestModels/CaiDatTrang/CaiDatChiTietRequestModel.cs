using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.CaiDatTrang
{
    public class CaiDatChiTietRequestModel
    {
        public long Id { get; set; }
        public string TieuDe { get; set; }
        public string TieuDeTiengAnh { get; set; }
        public string MoTa { get; set; }
        public string MoTaTiengAnh { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string LinkAnh { get; set; }

        
    }
}
